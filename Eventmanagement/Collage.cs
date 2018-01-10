using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Collage
    {
        public int CollageID { get; set; }
        public string CollageName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual ICollection<EventDetail> EventDetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
