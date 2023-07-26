# StockTable

This project shows real time stock information from live SignalR source and store most recent records in database and is licensed under the MIT License.

### Prerequisites

To build and run this project you need Visual studio code with below extensions

C# base language support v2.0.283
C# Dev Kit v0.2.100 
Nuget Package Manager v1.1.6
.NET Install Tool for Extension Authors  v1.6.0

Also you need to install SQL express with server instance name as SQLEXPRESS

### Cloning repository and installing required packages

Clone the repository using URL https://github.com/vramesh039/StockTable.git to local directory

Open Terminal in visual studio code and from your cloned destination directory navigate to the path StockTable\SignalRStocks.

```sh
dotnet add package Prism.Wpf
dotnet add package Prism.Unity
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.SignalR.Client
dotnet add package DotNetProjects.Extended.Wpf.Toolkit --version 5.0.103
```

Use the `--version` option to specify a preview version to install.

### Build

In the Terminal navigate to path StockTable\SignalRStocks

```sh
dotnet clean
dotnet build
```

### Run

```sh
dotnet run
```
