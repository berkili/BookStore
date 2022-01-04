using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete.Base;

namespace BookStore.Entity.Concrete
{
    public class Sales : ModelEntityBase
    {
        public Int64 ISBNId { get; set; }
        public int UserId { get; set; }
        public int Pieces { get; set; }
    }
}
