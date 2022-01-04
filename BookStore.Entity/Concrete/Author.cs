using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete.Base;

namespace BookStore.Entity.Concrete
{
    public class Author : ModelEntityBase
    {
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
