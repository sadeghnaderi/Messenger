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
    }
}