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
    public static class PublisherFileManager
    {
        public static readonly string AppPath = Path.Combine(Environment.CurrentDirectory, "BookStore");

        public static readonly string SavePath = Path.Combine(AppPath, "publisher.json");

        public static void CreateAppDirIfNotExists()
        {
            if (Directory.Exists(AppPath)) return;

            Directory.CreateDirectory(AppPath);
        }

        public static void CreatePublishersFileIfNotExits()
        {
            if (File.Exists(SavePath)) return;

            CreateAppDirIfNotExists();

            List<Publisher> publishers = new();
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(publishers, Formatting.Indented));
        }

        public static List<Publisher> GetPublishers()
        {
            CreatePublishersFileIfNotExits();

            List<Publisher> publishers = JsonConvert.DeserializeObject<List<Publisher>>(File.ReadAllText(SavePath));

            return publishers;
        }
        public static Publisher GetPublisherId(int publisherId)
        {
            CreatePublishersFileIfNotExits();
            Publisher publisher = new();

            if (GetPublishers().Count != 0)
            {
                foreach (var item in GetPublishers())
                {
                    if (item.Id == publisherId)
                    {
                        publisher = item;
                    }
                }
            }
            else
            {

            }
            return publisher;
        }
        public static bool SavePublishers(Publisher publisher)
        {
            CreatePublishersFileIfNotExits();

            var item = GetPublisherId(publisher.Id);
            var publishers = GetPublishers();

            if (item.Id != publisher.Id)
            {
                publishers.Add(publisher);
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(publishers, Formatting.Indented));
                }
                return true;
            }
            else
            {
                return false;
            }            
        }
        public static void UpdatePublisher(Publisher publisher)
        {
            var publishers = GetPublishers();

            foreach (var item in publishers)
            {
                if (item.Id == publisher.Id)
                {
                    item.Name = publisher.Name;
                }
            }

            var output = JsonConvert.SerializeObject(publishers, Formatting.Indented);
            File.WriteAllText(SavePath, output);
        }
        public static bool RemovePublisher(Publisher publisher)
        {
            CreatePublishersFileIfNotExits();

            var item = GetPublisherId(publisher.Id);
            var publishers = GetPublishers();

            if (item.Id == 0)
            {
                return false;
            }
            else
            {
                publishers.Remove(publishers.Find(x => x.Id == publisher.Id)); 
                using (StreamWriter file = new StreamWriter(SavePath))
                {
                    file.WriteLine(JsonConvert.SerializeObject(publishers, Formatting.Indented));
                }
                return true;
            }
        }
    }
}
