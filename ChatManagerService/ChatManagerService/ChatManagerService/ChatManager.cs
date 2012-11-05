using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using ChatManagerService.ChatEntity;
using ChatManagerService.ChatInterface;
using ChatManagerService.ChatRepository;
using ChatManagerService.ChatResponseObject;
using ChatManagerService.States;
namespace ChatManagerService.ChatManagerService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]   
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ChatManager : IChatManager
    {
        public ChatManager() { }

        public ResponseAttribute KeepAlive()
        {
            ResponseAttribute response = new ResponseAttribute
            {
                Response = true
            };
            return response;
        } 

        public UserResponse CreateUser(string username, string password, string emailAddress)
        {
            UserResponse response = new UserResponse();
            using (IChatRepository repo = new Repository(new ChatDbContext()))
            {
                try
                {
                    tbl_User user = repo.GetEntity(emailAddress);
                    if (user == (tbl_User)null)
                    {
                        response.Response = ResponseState.Ok.ToString();
                        string salt = Guid.NewGuid().ToString().Replace("-", "");
                        password = ChatUtility.ChatUtility.EncryptPassword(password, salt);
                        user = new tbl_User
                        {
                            Username = username,
                            Password = password,
                            Salt = salt,
                            EmailAddress = emailAddress,
                            CreateDate = DateTime.UtcNow
                        };
                        repo.InsertEntity(user);
                        response.ToUserResponse(user);
                    }
                    else
                        throw new InvalidOperationException("Account already exists.");
                }
                catch (Exception ex) {
                    response.Response = ResponseState.NotOK.ToString();
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public ResponseAttribute IsEmailExist(string emailAddress)
        {
            ResponseAttribute response = new ResponseAttribute();
            using (IChatRepository repo = new Repository(new ChatDbContext()))
            {
                response.Response = true;
                try
                {
                    tbl_User user = repo.GetEntity(emailAddress);
                    if (user != null)
                        response.Response = true;
                    else
                        response.Response = false;
                }
                catch (Exception ex) {
                    response.Response = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

        public ResponseAttribute IsUsernameExist(string username)
        {
            ResponseAttribute response = new ResponseAttribute();
            using (IChatRepository repo = new Repository(new ChatDbContext()))
            {
                response.Response = true;
                try
                {
                    tbl_User user = repo.GetEntityByUsername(username);
                    if (user != null)
                        response.Response = true;
                    else
                        response.Response = false;
                }
                catch (Exception ex) {
                    response.Response = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }
    }
}