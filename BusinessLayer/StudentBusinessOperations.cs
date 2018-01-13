using BusinessLayer.BusinessModel;
using DataLayer;
using Eventmanagement.DataBaseOperatios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBusinessOperations
    {
        private StudentLevelDataBaseOps studentLevelDataBaseOps = new StudentLevelDataBaseOps();
        public EventRegistrationBusinessModel EventRegistration(EventRegistrationBusinessModel eventRegister)
        {
            EventRegistration eventRegistrationDetails = new DataLayer.EventRegistration
            {
                EventDetailsID = eventRegister.EventDetailsID,
                UserID = eventRegister.UserID,
                CreateDate = DateTime.Now,
                MdifiedDate = DateTime.Now
            };
            studentLevelDataBaseOps.UserEventRegistration(eventRegistrationDetails);

            return eventRegister;
        }
    }
}
