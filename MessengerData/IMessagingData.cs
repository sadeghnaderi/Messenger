using Messenger.Entities;
using Messenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.MessengerData
{
    public interface IMessagingData
    {
        List<ConversationModel> GetConversations(string UserId);

        List<Message> ShowConversationMessages(string UserId, string ReceiverId,int ReceiverTypeId);

        string MakeMessageReaded(string UserId,string ReceiverId);

        string DeleteConversation(string UserId, string ReceiverId);

        string SendMessage(string UserId, string ReceiverId, int ReceiverTypeId, string Content, int ContentTypeId);

        string EditMessage(int MessageId, string NewContent);

        string DeleteMessage(int MessageId);

        string ForwardMessage(int MessageId, string UserId, string ReceiverId, string ForwardedFromUserId);

        string PinMessage(int MessageId);

        string SetReaction(int MessageId, string Reaction);

        string BookmarkMessage(int MessageId, string UserId);

        string AddGroup(string GroupName, string AdminId);

        string AddUsersToGroup(List<string> UserIds, string GroupId);

        string AddChannel(string Name, string AdminId);

        List<Bookmark> GetBookmarks(string UserId);

        string DeleteBookmark(int BookmarkId);
    }
}
