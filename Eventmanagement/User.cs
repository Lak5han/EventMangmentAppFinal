using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> CollageID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual Collage Collage { get; set; }
        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
        public virtual ICollection<EventRound> EventRounds { get; set; }
        public virtual ICollection<EventRound> EventRounds1 { get; set; }
        public virtual ICollection<EventRound> EventRounds2 { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
