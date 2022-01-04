using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete.Base;

namespace BookStore.Entity.Concrete
{
    public class Book : BookBase 
    {
        public Int64 ISBN { get; set; }        
        public int PublicationDate { get; set; }
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int TotalStock { get; set; }
    }
}
