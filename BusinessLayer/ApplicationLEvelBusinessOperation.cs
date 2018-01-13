using BusinessLayer.BusinessModel;
using DataLayer;
using Eventmanagement.DataBaseOperatios;
using ExceptionLogging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ApplicationLEvelBusinessOperation
    {
        private AdminDataBaseOperation adminDataBaseOperation = new AdminDataBaseOperation();
        private ApplicationLevelDataBaseOps applicationLevelDataBaseOps = new ApplicationLevelDataBaseOps();

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        /// <summary>
        /// check valid user or not and if valid user it will pass the user ID to track his sessions
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool IsValidUser(string userName, string password, out int userID)
        {
            bool isValidUser = false;
            User entityUserDetails = new User();            
            try
            {
                entityUserDetails = applicationLevelDataBaseOps.GetUserDetailByUserName(userName);
                if (string.Equals(entityUserDetails.UserName, userName) && string.Equals(Decrypt(entityUserDetails.Password), password))
                    isValidUser = true;                
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }

            userID = entityUserDetails != null ? entityUserDetails.UserID : 0  ;

            return isValidUser;
        }

        public UserBusinessModel GetUserDetailByUserName(string username)
        {
            User userdetails = new User();
            UserBusinessModel userModelDetails;
            try
            {
                userdetails = applicationLevelDataBaseOps.GetUserDetailByUserName(username);
                userModelDetails = new UserBusinessModel { UserID = userdetails.UserID };
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
                userModelDetails = new UserBusinessModel();
            }
            return userModelDetails;
        }

        public List<EventDetailBusinessModel> GetAllEvents()
        {
            List<EventDetailBusinessModel> allEvents = new List<EventDetailBusinessModel>();
            List<EventDetail> listofEvents = new List<EventDetail>();
            listofEvents = applicationLevelDataBaseOps.GetAllEventDetail();

            foreach (EventDetail item in listofEvents)
            {
                EventDetailBusinessModel eventItem = new EventDetailBusinessModel { EventName =item.EventName,
                    EventDate = item.EventDate,
                    EventDescription = item.EventDescription,
                    EventDetailID = item.EventDetailID,
                    EventType = item.EventType,
                    CollageID = item.CollageID
                };
                allEvents.Add(eventItem);
            }

            return allEvents;
        }

        public List<CollageBusinessModel> GetAllCollage()
        {
            List<Collage> listofCollage = new List<Collage>();
            List<CollageBusinessModel> allCollages = new List<CollageBusinessModel>();
            try
            {
                listofCollage = applicationLevelDataBaseOps.GetAllCollage().ToList();
                foreach (Collage item in listofCollage)
                {
                    CollageBusinessModel collageItem = new CollageBusinessModel { CollageID = item.CollageID,
                        CollageName = item.CollageName  };
                    allCollages.Add(collageItem);
                }

            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
            }
            return allCollages;
        }
        public UserRoleBusinessModel GetUserRolebyUserID(int userID)
        {
            UserRoleBusinessModel usermodel;
            try
            {
                UserRole userRole = applicationLevelDataBaseOps.GetUserRolebyUserID(userID);
                Role role = applicationLevelDataBaseOps.GetRoleDetailsByID(userRole.RoleID);
                usermodel = new UserRoleBusinessModel
                {
                    RoleID = userRole.RoleID,
                    UderID = userRole.UderID,
                    UserRoleID = userRole.UserRoleID,
                    RoleName = role.RoleName
                };
            }
            catch (Exception ex)
            {
                usermodel = new UserRoleBusinessModel();
                ExceptionTracker.SendErrorToText(ex); 
            }
            return usermodel;
        }
        public List<RolesBusinessModel> GetAllRole()
        {
            List<RolesBusinessModel> usermodel = new List<RolesBusinessModel>();
            List<Role> userRoles = new List<Role>();
            try
            {
                userRoles = applicationLevelDataBaseOps.GetAllRoles();
                foreach (Role item in userRoles)
                {
                    RolesBusinessModel newRole = new RolesBusinessModel
                    {
                        RoleID = item.RoleID,
                        RoleName = item.RoleName
                    };
                    usermodel.Add(newRole);
                }
            }
            catch (Exception ex)
            {
                usermodel = new List<RolesBusinessModel>();
                ExceptionTracker.SendErrorToText(ex);
            }
            return usermodel;
        }

        public EventDetailBusinessModel GetEventDetailById(int id)
        {
            EventDetail eventEntity = new EventDetail();
            EventDetailBusinessModel eventItem;
            try
            {
                eventEntity = applicationLevelDataBaseOps.GetEventDetailById(id);
                eventItem = new EventDetailBusinessModel
                {
                    EventName = eventEntity.EventName,
                    EventDate = eventEntity.EventDate,
                    EventDescription = eventEntity.EventDescription,
                    EventDetailID = eventEntity.EventDetailID,
                    EventType = eventEntity.EventType,
                    CollageID = eventEntity.CollageID
                };
            }
            catch (Exception ex)
            {
                eventItem = new EventDetailBusinessModel();
                ExceptionTracker.SendErrorToText(ex);
            }
            
            return eventItem;
        }

        public UserBusinessModel GetUserDetailByUserId(int id)
        {
            User UserDetail = new User();
            UserBusinessModel userBusinessModel;
            try
            {
                UserDetail = applicationLevelDataBaseOps.GetUserDetailByUserId(id);
                userBusinessModel = new UserBusinessModel
                {
                    FirstName = UserDetail.FirstName,
                    LastName = UserDetail.LastName,
                    UserID = UserDetail.UserID
                };
            }
            catch (Exception ex)
            {
                ExceptionTracker.SendErrorToText(ex);
                userBusinessModel = new UserBusinessModel();
            }
            return userBusinessModel;
        }
    }
}
