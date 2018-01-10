using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
