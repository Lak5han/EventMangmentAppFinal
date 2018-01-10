﻿using BusinessLayer;
using BusinessLayer.BusinessModel;
using EventManagmentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagmentWeb.Controllers
{
    public static class StaticMethod
    {
        private static ApplicationLEvelBusinessOperation aplicationLEvelBusinessOperation = new ApplicationLEvelBusinessOperation();
        public static List<CollageModel> GetAlCollages()
        {
            List<CollageBusinessModel> listOfCllage = new List<CollageBusinessModel>();
            List<CollageModel> alCollages = new List<CollageModel>();
            listOfCllage = aplicationLEvelBusinessOperation.GetAllCollage().ToList();


            foreach (CollageBusinessModel item in listOfCllage)
            {
                CollageModel collageItem = new CollageModel
                {
                    CollageID = item.CollageID,
                    CollageName = item.CollageName
                };
                alCollages.Add(collageItem);
            }
            return alCollages;
        }
    }
}