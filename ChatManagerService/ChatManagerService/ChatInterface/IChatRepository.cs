using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatManagerService.ChatEntity;

namespace ChatManagerService.ChatInterface
{
    public interface IChatRepository : IDisposable
    {
        void Commit();
        void InsertEntity(tbl_User user);
        tbl_User GetEntity(int userID);
        tbl_User GetEntity(string emailAddress);
        tbl_User GetEntityByUsername(string username);
        List<tbl_User> GetAllEntities();
        int CountEntities();
    }
}
