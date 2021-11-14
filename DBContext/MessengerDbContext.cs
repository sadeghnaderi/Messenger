using Library.Models;
using Messenger.IdentityAuth;
using Messenger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DBContext
{
    public class MessengerDbContext : IdentityDbContext<ApplicationUser>
    {
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}
