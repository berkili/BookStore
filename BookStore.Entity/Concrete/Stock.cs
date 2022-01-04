using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete.Base;

namespace BookStore.Entity.Concrete
{
    public class Stock : EntityBase
    {
        public Int64 ISBNId { get; set; }
        public DateTime CreateTime { get; set; }
        public int AmountOfStock { get; set; }
    }
}
