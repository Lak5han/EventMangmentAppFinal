using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessModel
{
    public class UserBusinessModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> CollageID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }
    }
}
