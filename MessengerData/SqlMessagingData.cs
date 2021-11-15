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
            throw new NotImplementedException();
        }

        public string AddGroup(string GroupName, string AdminId)
        {
            throw new NotImplementedException();
        }

        public string AddUserToGroup(List<string> UserIds, string GroupId)
        {
            throw new NotImplementedException();
        }

        public string BookmarkMessage(int MessageId, string UserId)
        {
            throw new NotImplementedException();
        }

        public string DeleteBookmark(int BookmarkId)
        {
            throw new NotImplementedException();
        }

        public string DeleteConversation(string UserId, string ReceiverId)
        {
            throw new NotImplementedException();
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
