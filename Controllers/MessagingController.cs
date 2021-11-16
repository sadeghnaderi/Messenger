using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.MessengerData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Controllers
{
    [Authorize]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        private IMessagingData _MessagingData;

        public MessagingController(IMessagingData messagingData)
        {
            _MessagingData = messagingData;
        }

        [HttpPost]
        [Route("api/AddGroup")]
        public IActionResult AddGroup(string GroupName, string AdminId)
        {
            return Ok(_MessagingData.AddGroup(GroupName, AdminId));
        }

        [HttpPost]
        [Route("api/AddChannel")]
        [Authorize(Roles = "User")]
        public IActionResult AddChannel(string Name, string AdminId)
        {
            return Ok(_MessagingData.AddChannel(Name, AdminId));
        }

        [HttpPost]
        [Route("api/AddUsersToGroup")]
        [Authorize(Roles = "User")]
        public IActionResult AddUsersToGroup(List<string> UserIds, string GroupId)
        {
            return Ok(_MessagingData.AddUsersToGroup(UserIds, GroupId));
        }

        [HttpPost]
        [Route("api/BookmarkMessage")]
        [Authorize(Roles = "User")]
        public IActionResult BookmarkMessage(int MessageId, string UserId)
        {
            return Ok(_MessagingData.BookmarkMessage(MessageId, UserId));
        }

        [HttpPost]
        [Route("api/DeleteBookmark")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteBookmark(int BookmarkId)
        {
            return Ok(_MessagingData.DeleteBookmark(BookmarkId));
        }

        
        [HttpPost]
        [Route("api/DeleteConversation")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteConversation(string UserId, string ReceiverId)
        {
            return Ok(_MessagingData.DeleteConversation(UserId,ReceiverId));
        }

        [HttpPost]
        [Route("api/DeleteMessage")]
        [Authorize(Roles = "User")]
        public IActionResult DeleteMessage(int MessageId)
        {
            return Ok(_MessagingData.DeleteMessage(MessageId));
        }

        [HttpPost]
        [Route("api/EditMessage")]
        [Authorize(Roles = "User")]
        public IActionResult EditMessage(int MessageId, string NewContent)
        {
            return Ok(_MessagingData.EditMessage(MessageId,NewContent));
        }

        [HttpPost]
        [Route("api/SendMessage")]
        [Authorize(Roles = "User")]
        public IActionResult SendMessage(string UserId, string ReceiverId, int ReceiverTypeId, string Content, int ContentTypeId)
        {
            return Ok(_MessagingData.SendMessage(UserId,ReceiverId,ReceiverTypeId,Content,ContentTypeId));
        }

        [HttpPost]
        [Route("api/ForwardMessage")]
        [Authorize(Roles = "User")]
        public IActionResult ForwardMessage(int MessageId, string UserId, string ReceiverId, string ForwardedFromUserId)
        {
            return Ok(_MessagingData.ForwardMessage(MessageId, UserId,ReceiverId,ForwardedFromUserId));
        }

        [HttpPost]
        [Route("api/MakeMessageReaded")]
        [Authorize(Roles = "User")]
        public IActionResult MakeMessageReaded(string UserId, string ReceiverId)
        {
            return Ok(_MessagingData.MakeMessageReaded(UserId,ReceiverId));
        }

        [HttpPost]
        [Route("api/PinMessage")]
        [Authorize(Roles = "User")]
        public IActionResult PinMessage(int MessageId)
        {
            return Ok(_MessagingData.PinMessage(MessageId));
        }
    }
}