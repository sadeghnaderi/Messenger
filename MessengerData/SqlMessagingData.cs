using Messenger.DBContext;
using Messenger.Entities;
using Messenger.IdentityAuth;
using Messenger.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            var DbMessage = _MessengerDbContext.Messages.Where(m => m.Id == MessageId).SingleOrDefault();
            DbMessage.IsDeleted = true;

            _MessengerDbContext.SaveChanges();

            return "Message Deleted Successfully";
        }

        public string EditMessage(int MessageId, string NewContent)
        {
            var DbMessage = _MessengerDbContext.Messages.Where(m => m.Id == MessageId).SingleOrDefault();

            DbMessage.Content = NewContent;
            _MessengerDbContext.SaveChanges();

            return "Message Edited Successfully";
        }

        public string ForwardMessage(int MessageId, string UserId, string ReceiverId, string ForwardedFromUserId)
        {
            var DbMessage = _MessengerDbContext.Messages.Where(m => m.Id == MessageId).SingleOrDefault();

            DateTime today = DateTime.Today.Date;
            DateTime now = today.Date;

            var message = new Message
            {
                SenderId = UserId,
                ReceiverId = ReceiverId,
                ReceiverTypeId = DbMessage.ReceiverTypeId,
                Content = DbMessage.Content,
                ContentTypeId = DbMessage.ContentTypeId,
                IsDeleted = false,
                HasReaction = false,
                DateTime = now,
                IsUserSeen = false,
                IsForwarded = true,
                ForwardedFromId = ForwardedFromUserId
            };

            _MessengerDbContext.Add(message);


            var DbConversation = _MessengerDbContext.Conversation.Where(m => m.SenderId == UserId && m.ReceiverId == ReceiverId).SingleOrDefault();
            if (DbConversation == null)
            {
                var conversation = new Conversation
                {
                    SenderId = UserId,
                    ReceiverId = ReceiverId,
                    ReceiverTypeId = DbMessage.ReceiverTypeId,
                    Active = true
                };
                _MessengerDbContext.Conversation.Add(conversation);
            }

            DbConversation = _MessengerDbContext.Conversation.Where(m => m.SenderId == ReceiverId && m.ReceiverId == UserId).SingleOrDefault();
            if (DbConversation == null)
            {
                var conversation = new Conversation
                {
                    SenderId = ReceiverId,
                    ReceiverId = UserId,
                    ReceiverTypeId = DbMessage.ReceiverTypeId,
                    Active = true
                };
                _MessengerDbContext.Conversation.Add(conversation);
            }

            _MessengerDbContext.SaveChanges();

            return "Message Sent Successfully";
        }

        public List<Bookmark> GetBookmarks(string UserId)
        {
            List<Bookmark> DbBookmarks = _MessengerDbContext.Bookmark.Where(m => m.UserId == UserId).Include(m => m.Message).OrderByDescending(m => m.Id).ToList();

            return DbBookmarks;
        }

        public List<ConversationModel> GetConversations(string UserId)
        {
            List<Conversation> DBConversations = _MessengerDbContext.Conversation.Where(m => m.SenderId == UserId).OrderByDescending(m => m.Id).ToList();

            List<ConversationModel> ConversationModels = new List<ConversationModel> { } ;

            foreach(var Conversation in DBConversations)
            {
                var NewConverstaionModel = new ConversationModel { };

                if (Conversation.ReceiverTypeId == 1)
                {
                    NewConverstaionModel = new ConversationModel
                    {
                        Name = _MessengerDbContext.User.Where(m => m.Id == Conversation.ReceiverId).SingleOrDefault().Name,
                        ReceiverId = Conversation.ReceiverId,
                        ReceiverTypeId = Conversation.ReceiverTypeId
                    };
                }   
                else
                {
                    NewConverstaionModel = new ConversationModel
                    {
                        Name = _MessengerDbContext.Group.Where(m => m.Id == Conversation.ReceiverId).SingleOrDefault().Name,
                        ReceiverId = Conversation.ReceiverId,
                        ReceiverTypeId = Conversation.ReceiverTypeId
                    };
                }

                ConversationModels.Add(NewConverstaionModel);
            }

            return ConversationModels;
        }

        public string MakeMessageReaded(string UserId, string ReceiverId)
        {
            List<Message> DbMessage = _MessengerDbContext.Messages.Where(m => m.SenderId == ReceiverId && m.ReceiverId == UserId && m.IsUserSeen == false).ToList();

            if (DbMessage != null)
            {
                foreach (var Message in DbMessage)
                    Message.IsUserSeen = true;

                _MessengerDbContext.SaveChanges();
            }


            return "Messages Updated Successfull";
        }

        public string PinMessage(int MessageId)
        {
            var DbMessage = _MessengerDbContext.Messages.Where(m => m.Id == MessageId).SingleOrDefault();

            if (DbMessage.ReceiverTypeId == 1)
                return "You can't pin message in personal chats";

            string GroupId = DbMessage.ReceiverId;

            _MessengerDbContext.Group.Where(m => m.Id == GroupId).SingleOrDefault().PinMessageId = MessageId;
            _MessengerDbContext.SaveChanges();

            return "Message Pinned Successfully";
        }

        public string SendMessage(string UserId, string ReceiverId, int ReceiverTypeId, string Content, int ContentTypeId)
        {
            DateTime today = DateTime.Today.Date;
            DateTime now = today.Date;

            var message = new Message
            {
                SenderId = UserId,
                ReceiverId = ReceiverId,
                ReceiverTypeId = ReceiverTypeId,
                Content = Content,
                ContentTypeId = ContentTypeId,
                IsDeleted = false,
                HasReaction = false,
                DateTime = now,
                IsUserSeen = false
            };
            _MessengerDbContext.Add(message);


            var DbConversation = _MessengerDbContext.Conversation.Where(m => m.SenderId == UserId && m.ReceiverId == ReceiverId).SingleOrDefault();
            if(DbConversation == null)
            {
                var conversation = new Conversation
                {
                    SenderId = UserId,
                    ReceiverId = ReceiverId,
                    ReceiverTypeId = ReceiverTypeId,
                    Active = true
                };
                _MessengerDbContext.Conversation.Add(conversation);
            }

            DbConversation = _MessengerDbContext.Conversation.Where(m => m.SenderId == ReceiverId && m.ReceiverId == UserId).SingleOrDefault();
            if (DbConversation == null)
            {
                var conversation = new Conversation
                {
                    SenderId = ReceiverId,
                    ReceiverId = UserId,
                    ReceiverTypeId = ReceiverTypeId,
                    Active = true
                };
                _MessengerDbContext.Conversation.Add(conversation);
            }

            _MessengerDbContext.SaveChanges();

            return "Message Sent Successfully";


        }

        public string SetReaction(int MessageId, string Reaction)
        {
            var DbMessage = _MessengerDbContext.Messages.Where(m => m.Id == MessageId).SingleOrDefault();

            DbMessage.HasReaction = true;
            DbMessage.Reaction = Reaction;

            _MessengerDbContext.SaveChanges();

            return "Reaction Saved Successfully";
        }

        public List<Message> ShowConversationMessages(string UserId, string ReceiverId, int ReceiverTypeId)
        {
            List<Message> DbMessages = _MessengerDbContext.Messages.Where(m => m.SenderId == UserId && m.ReceiverId == ReceiverId || m.SenderId == ReceiverId && m.ReceiverId == UserId).Where(m => m.IsDeleted == false).Include(m => m.ContentType).Include(m => m.ReceiverType).ToList().OrderByDescending(m => m.DateTime).ToList();

            return DbMessages;
        }
    }
}
