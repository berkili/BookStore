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
    public static class SalesFileManager
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "sales.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }

        public static void CreateSalesFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<Sales> sales = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(sales, Formatting.Indented));
        }

        public static List<Sales> GetSales()
        {
            CreateSalesFileIfNotExits();

            List<Sales> sales = JsonConvert.DeserializeObject<List<Sales>>(File.ReadAllText(SavePath));

            return sales;
        }
        public static Sales GetSalesId(int SalesId)
        {
            CreateSalesFileIfNotExits();
            Sales sales = new();

            if (GetSales().Count != 0)
            {
                foreach (var item in GetSales())
                {
                    if (item.Id == SalesId)
                    {
                        sales = item;
                    }
                }
            }
            else
            {

            }
            return sales;
        }
        public static bool SaveSales(Sales sales)
        {
            CreateSalesFileIfNotExits();

            var item = GetSalesId(sales.Id);
            var saleList = GetSales();

            if (item.Id == 0)
            {
                saleList.Add(sales);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(saleList, Formatting.Indented));
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
