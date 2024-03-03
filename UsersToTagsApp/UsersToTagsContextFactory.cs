using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UsersToTagsApp.Core.Context;

namespace UsersToTagsApp
{
    public class UsersToTagsContextFactory : IDesignTimeDbContextFactory<UsersToTagsContext>
    {
        public UsersToTagsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersToTagsContext>();
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("UsersToTagsDatabase"));

            return new UsersToTagsContext(optionsBuilder.Options);
        }
    }
}
