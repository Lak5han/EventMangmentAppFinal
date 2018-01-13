using BusinessLayer.BusinessModel;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class StaticBusinessMethods
    {
        public static List<UserBusinessModel> userDetailConvertTOBModel(List<User> userEntity)
        {
            List<UserBusinessModel> UserBusinessModelList = new List<UserBusinessModel>();
            foreach (User item in userEntity)
            {
                UserBusinessModel user = new UserBusinessModel
                {
                    CollageID = item.CollageID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserID = item.UserID,
                    UserName = item.UserName
                };
                UserBusinessModelList.Add(user);
            }
            return UserBusinessModelList;
        }
    }
}
