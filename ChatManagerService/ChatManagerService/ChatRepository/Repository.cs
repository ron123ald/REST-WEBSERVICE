using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatManagerService.ChatEntity;
using ChatManagerService.ChatInterface;

namespace ChatManagerService.ChatRepository
{
    public class Repository : IChatRepository, IDisposable
    {
        private ChatDbContext _context = default(ChatDbContext);
        public Repository(ChatDbContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void InsertEntity(tbl_User user)
        {
            this._context.tbl_User.Add(user);
            this.Commit();
        }

        public tbl_User GetEntity(int UserID)
        {
            return (from m in this._context.tbl_User
                    where m.UserID == UserID
                    select m).SingleOrDefault();
        }

        public List<tbl_User> GetAllEntities()
        {
            return (from m in this._context.tbl_User
                    select m).ToList();
        }

        public int CountEntities()
        {
            return (from m in this._context.tbl_User
                    select m).Count();
        }


        public tbl_User GetEntity(string emailAddress)
        {
            return (from m in this._context.tbl_User
                    where string.Compare(m.EmailAddress, emailAddress, true) == 0
                    select m).SingleOrDefault();
        }

        public tbl_User GetEntityByUsername(string username)
        {
            return (from m in this._context.tbl_User
                    where string.Compare(m.Username, username, true) == 0
                    select m).SingleOrDefault();
        }

    }
}