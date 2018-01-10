using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EventRound
    {
        public int EventRoundID { get; set; }
        public int EventDetailID { get; set; }
        public int FirstUserID { get; set; }
        public int SecondUserID { get; set; }
        public int ThirdUserID { get; set; }
        public string EventRoundDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime MdifiedDate { get; set; }

        public virtual EventDetail EventDetail { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }

    }
}
