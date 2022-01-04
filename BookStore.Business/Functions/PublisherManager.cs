using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Abstract;
using BookStore.Entity.Concrete;
using BookStore.DataAccess.Functions;

namespace BookStore.Business.Functions
{
    public class PublisherManager : IPublisherService
    {
        public List<Publisher> publishers = new();
        public bool AddPublisher(Publisher publisher)
        {
            int publisherId = GetPublishersList().Select(x => x.Id).LastOrDefault();
            publisher.Id = publisherId == 0 ? 1 : publisherId + 1;
            var status = PublisherFileManager.SavePublishers(publisher);
            return status;
        }

        public Publisher GetPublisherId(int publisherId)
        {
            return PublisherFileManager.GetPublisherId(publisherId);
        }

        public List<Publisher> GetPublishersList()
        {
            return publishers = PublisherFileManager.GetPublishers();
        }

        public bool RemovePublisher(Publisher publisher)
        {
            var status = PublisherFileManager.RemovePublisher(publisher);
            return status;
        }

        public void UpdatePublisher(Publisher publisherToUpdate)
        {
            PublisherFileManager.UpdatePublisher(publisherToUpdate);
        }
    }
}
