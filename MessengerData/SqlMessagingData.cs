using Messenger.DBContext;
using Messenger.Entities;
using Messenger.IdentityAuth;
using Messenger.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.MessengerData
{
    public class SqlMessagingData : IMessagingData
    {
        private readonly UserManager<ApplicationUser> userManager;
        private MessengerDbContext _MessengerDbContext;
        public SqlMessagingData(UserManager<ApplicationUser> userManager, MessengerDbContext messengerDbContext)
        {
            this.userManager = userManager;
            _MessengerDbContext = messengerDbContext;
        }
        public string AddChannel(string Name, string AdminId)
        {
            var Channel = new Group
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                AdminId = AdminId,
                IsChannel = true
            };

            _MessengerDbContext.Group.Add(Channel);
            _MessengerDbContext.SaveChanges();

            return "Channel Added Successfully";
        }

        public string AddGroup(string GroupName, string AdminId)
        {
            var Group = new Group
            {
                Id = Guid.NewGuid().ToString(),
                Name = GroupName,
                AdminId = AdminId,
                IsChannel = false
            };

            _MessengerDbContext.Group.Add(Group);
            _MessengerDbContext.SaveChanges();

            return "Group Added Successfully";
        }

        public string AddUsersToGroup(List<string> UserIds, string GroupId)
        {
            foreach (string UserId in UserIds)
            {
                var GroupUser = new GroupUsers
                {
                    GroupId = GroupId,
                    UserId = UserId
                };

                _MessengerDbContext.GroupUsers.Add(GroupUser);
            }
            
            _MessengerDbContext.SaveChanges();

            return "Users Added To Group Successfully";
        }

        public string BookmarkMessage(int MessageId, string UserId)
        {
            var Bookmark = new Bookmark
            {
                UserId = UserId,
                MessageId = MessageId
            };

            _MessengerDbContext.Bookmark.Add(Bookmark);
            _MessengerDbContext.SaveChanges();

            return "Bookmark Added Successfully";
        }

        public string DeleteBookmark(int BookmarkId)
        {
            var DbBookmark = _MessengerDbContext.Bookmark.Where(m => m.Id == BookmarkId).SingleOrDefault();

            _MessengerDbContext.Remove(DbBookmark);
            _MessengerDbContext.SaveChanges();

            return "Bookmark Deleted Successfully";
        }

        public string DeleteConversation(string UserId, string ReceiverId)
        {
            var DbConversation = _MessengerDbContext.Conversation.Where(m => m.SenderId == UserId && m.ReceiverId == ReceiverId).SingleOrDefault();

            DbConversation.Active = false;
            _MessengerDbContext.SaveChanges();

            return "Conversation Deleted Successfully";
        }

        public string DeleteMessage(int MessageId)
        {
            throw new NotImplementedException();
        }

        public string EditMessage(int MessageId, string NewContent)
        {
            throw new NotImplementedException();
        }

        public string ForwardMessage(int MessageId, string UserId, string ReceiverId, string ForwardedFromUserId)
        {
            throw new NotImplementedException();
        }

        public List<Bookmark> GetBookmarks(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<ConversationModel> GetConversations(string UserId)
        {
            throw new NotImplementedException();
        }

        public string MakeMessageReaded(string UserId, string ReceiverId)
        {
            throw new NotImplementedException();
        }

        public string PinMessage(int MessageId)
        {
            throw new NotImplementedException();
        }

        public string SendMessage(string UserId, string ReceiverId, int ReceiverTypeId, string Content, int ContentTypeId)
        {
            throw new NotImplementedException();
        }

        public string SetReaction(int MessageId, string Reaction)
        {
            throw new NotImplementedException();
        }

        public List<Message> ShowConversationMessages(string UserId, string ReceiverId, int ReceiverTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
