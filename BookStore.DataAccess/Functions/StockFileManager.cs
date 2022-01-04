using BookStore.Entity.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Functions
{
    public static class StockFileManager
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "stocks.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }

        public static void CreateStocksFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<Stock> stocks = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(stocks, Formatting.Indented));
        }

        public static List<Stock> GetStocks()
        {
            CreateStocksFileIfNotExits();

            List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(File.ReadAllText(SavePath));

            return stocks;
        }
        public static Stock GetStockId(int stockId)
        {
            CreateStocksFileIfNotExits();
            Stock stock = new();

            if (GetStocks().Count != 0)
            {
                foreach (var item in GetStocks())
                {
                    if (item.Id == stockId)
                    {
                        stock = item;
                    }
                }
            }
            else
            {

            }
            return stock;
        }
        public static bool SaveStocks(Stock stock)
        {
            CreateStocksFileIfNotExits();

            var item = GetStockId(stock.Id);
            var stocks = GetStocks();

            if(item.Id == 0)
            {
                stocks.Add(stock);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(stocks, Formatting.Indented));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void UpdateStock(Stock stock)
        {
            var stocks = GetStocks();

            foreach (var item in stocks)
            {
                if (item.Id == stock.Id)
                {
                    item.ISBNId = stock.ISBNId;
                    item.AmountOfStock = stock.AmountOfStock;
                }
            }
        }
    }
}
