using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations;

namespace StockTable
{
    public class StockUpdate : BindableBase
    {
        private string _symbol;
        [Key]
        public string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        private double _price;
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private double _change;
        public double Change
        {
            get => _change;
            set => SetProperty(ref _change, value);
        }

        private DateTime _lastUpdated;
        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set => SetProperty(ref _lastUpdated, value);
        }
    }
}