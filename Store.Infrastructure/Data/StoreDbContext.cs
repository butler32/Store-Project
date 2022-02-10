using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Data.Configuration;
using Store.Core.Entities;

namespace Store.Infrastructure.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SupportCase> SupportCases { get; set; }
        public DbSet<SupportMessage> SupportMessages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Member> Members { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new GameConfiguration().Configure(modelBuilder.Entity<Game>());
            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
            new SupportMessageConfiguration().Configure(modelBuilder.Entity<SupportMessage>());
            new SupportCaseConfiguration().Configure(modelBuilder.Entity<SupportCase>());
            new FriendRequestConfiguration().Configure(modelBuilder.Entity<FriendRequest>());
            new MemberConfiguration().Configure(modelBuilder.Entity<Member>());
            new LibriaryConfiguration().Configure(modelBuilder.Entity<Libriary>());
            new CartConfiguration().Configure(modelBuilder.Entity<Cart>());
            new ImageConfiguration().Configure(modelBuilder.Entity<Image>());
            new ScreenshotConfiguration().Configure(modelBuilder.Entity<Screenshot>());
            new AvatarConfiguration().Configure(modelBuilder.Entity<Avatar>());
        }
    }
}