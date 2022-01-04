using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete.Base;

namespace BookStore.Entity.Concrete
{
    public class Publisher : ModelEntityBase
    {
        public virtual ICollection<Author> Authors { get; set; }
    }
}
