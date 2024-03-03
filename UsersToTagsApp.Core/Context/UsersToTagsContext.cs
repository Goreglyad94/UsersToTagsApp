using Microsoft.EntityFrameworkCore;
using UsersToTagsApp.Domain.Tags;
using UsersToTagsApp.Domain.Users;

namespace UsersToTagsApp.Core.Context
{
    public class UsersToTagsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public UsersToTagsContext(DbContextOptions<UsersToTagsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersToTagsContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
