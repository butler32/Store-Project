using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=StoreDataBase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new GameConfiguration().Configure(modelBuilder.Entity<Game>());
            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
            new SupportMessageConfiguration().Configure(modelBuilder.Entity<SupportMessage>());
            new SupportCaseConfiguration().Configure(modelBuilder.Entity<SupportCase>());
            new FriendConfiguration().Configure(modelBuilder.Entity <Friend>());
        }
    }
}
