using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace StockTable
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly HubConnection _hubConnection;
        private ObservableCollection<StockUpdate> _stockUpdates = new();
        private Color _risingStockColor = Color.FromRgb(0, 100, 0);
        private Color _dowingStockColor = Color.FromRgb(139, 0, 0);

        public Color RisingStockColor
        {
            get => _risingStockColor;
            set {
                SetProperty(ref _risingStockColor, value);
            } 
        }

        public Color DowingStockColor
        {
            get => _dowingStockColor;
            set => SetProperty(ref _dowingStockColor, value);
        }

        public ObservableCollection<StockUpdate> StockUpdates
        {
            get => _stockUpdates;
            set { SetProperty(ref _stockUpdates, value); }
        }

        public MainWindowViewModel()
        {            
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://js.devexpress.com/Demos/NetCore/liveUpdateSignalRHub")
                .Build();

            _hubConnection.On<StockUpdate>("updateStockPrice", OnReceiveStockUpdate);

            try
            {
                _hubConnection.StartAsync().Wait();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnReceiveStockUpdate(StockUpdate update)
        {
            RefreshStockUpdates(update);
            UpdateDatabaseWithLatestInfo(update);
        }

        private void RefreshStockUpdates(StockUpdate update)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                var temp = _stockUpdates;
                var stock = temp.Where(x => x.Symbol == update.Symbol).FirstOrDefault();

                if (stock != null)
                {
                    temp.Remove(stock);

                    stock = new StockUpdate()
                    {
                        Change = update.Change,
                        Price = update.Price,
                        Symbol = update.Symbol,
                        LastUpdated = DateTime.Now,
                    };
                }
                else
                {
                    stock = new StockUpdate()
                    {
                        Change = update.Change,
                        Price = update.Price,
                        Symbol = update.Symbol,
                        LastUpdated = DateTime.Now,
                    };
                }

                temp.Add(stock);
                StockUpdates = temp;
            });
        }

        private static void UpdateDatabaseWithLatestInfo(StockUpdate update)
        {
            using StockDbContext dbContext = new();
            var existingRecord = dbContext.StockUpdates.SingleOrDefault(u => u.Symbol == update.Symbol);

            if (existingRecord == null)
            {
                dbContext.StockUpdates.Add(update);
            }
            else
            {
                existingRecord.Price = update.Price;
                existingRecord.Change = update.Change;
                existingRecord.LastUpdated = update.LastUpdated;

                var allUpdatesForSymbol = dbContext.StockUpdates
                    .Where(u => u.Symbol == update.Symbol)
                    .OrderByDescending(u => u.LastUpdated)
                    .Take(10)
                    .ToList();

                var recordsToRemove = dbContext.StockUpdates
                    .Where(u => u.Symbol == update.Symbol && !allUpdatesForSymbol.Contains(u))
                    .ToList();

                dbContext.StockUpdates.RemoveRange(recordsToRemove);
            }

            dbContext.SaveChanges();
        }
    }
}