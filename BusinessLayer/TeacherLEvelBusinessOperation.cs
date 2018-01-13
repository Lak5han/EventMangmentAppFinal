﻿using BusinessLayer.BusinessModel;
using DataLayer;
using Eventmanagement.DataBaseOperatios;
using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TeacherLEvelBusinessOperation
    {
        private TeacherLevelDataBaseOps adminDataBaseOperation = new TeacherLevelDataBaseOps();

        public List<EventRegistrationBusinessModel> UserEventRegistration(int id)
        {
            List<EventRegistrationBusinessModel> EventRegistrationList = new List<EventRegistrationBusinessModel>();
            List<EventRegistration> EventRegistrationListEntity = new List<EventRegistration>();
            try
            {
                EventRegistrationListEntity = adminDataBaseOperation.ListofEventRegistration(id);
                foreach (EventRegistration item in EventRegistrationListEntity)
                {
                    EventRegistrationBusinessModel EventRegistrationItemt = new EventRegistrationBusinessModel
                    {
                        EventRegistrationID = item.EventRegistrationID,
                        EventDetailsID = item.EventDetailsID,
                        UserID = item.UserID,
                        UserAttendance = item.UserAttendance
                    };
                    EventRegistrationList.Add(EventRegistrationItemt);
                }
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }

            return EventRegistrationList;
        }
    }
}
