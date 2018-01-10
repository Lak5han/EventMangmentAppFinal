using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public int RoleID { get; set; }
        public int UderID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
