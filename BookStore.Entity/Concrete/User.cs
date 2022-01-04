using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete.Base;

namespace BookStore.Entity.Concrete
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public DateTime CreationTime { get; set; }
        public string MailAdress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
