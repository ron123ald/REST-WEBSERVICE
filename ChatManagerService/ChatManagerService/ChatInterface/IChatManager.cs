using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ChatManagerService.ChatResponseObject;

namespace ChatManagerService.ChatInterface
{
    [ServiceContract]
    public interface IChatManager
    {
        [OperationContract]
        [WebGet(UriTemplate = "KeepAlive")]
        ResponseAttribute KeepAlive();

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateUser/{username}/{password}/{emailAddress}", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        UserResponse CreateUser(string username, string password, string emailAddress);
        
        [OperationContract]
        [WebGet(UriTemplate = "IsEmailExist/{emailAddress}")]
        ResponseAttribute IsEmailExist(string emailAddress);

        [OperationContract]
        [WebGet(UriTemplate = "IsUsernameExist/{username}")]
        ResponseAttribute IsUsernameExist(string username);
    }
}
