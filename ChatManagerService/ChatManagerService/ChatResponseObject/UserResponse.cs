using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatManagerService.ChatEntity;

namespace ChatManagerService.ChatResponseObject
{
    public class UserResponse : CommonAttribute
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string emailAddress { get; set; }
        public string createDate { get; set; }

        public UserResponse()
        {
        }

        public UserResponse(string username, string password, string emailAddress)
        {
            this.username = username;
            this.password = password;
            this.emailAddress = emailAddress;
        }

        public void ToUserResponse(tbl_User user)
        {
            this.userID = user.UserID;
            this.username = user.Username;
            this.password = user.Password;
            this.emailAddress = user.EmailAddress;
            this.createDate = user.CreateDate.ToString();
        }
    }
}