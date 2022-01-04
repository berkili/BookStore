using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Abstract
{
    public interface IPublisherService
    {
        bool AddPublisher(Publisher publisher);
        bool RemovePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisherToUpdate);
        Publisher GetPublisherId(int publisherId);
        List<Publisher> GetPublishersList();
    }
}
