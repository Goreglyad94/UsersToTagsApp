using Microsoft.EntityFrameworkCore;
using UsersToTagsApp.Core.Context;

namespace UsersToTagsApp.Test.Infrastructure.Helper
{
    public class DbContextHelper : IDisposable
    {
        public UsersToTagsContext Context { get; set; }
        public string User1Guid = "74ffc57e-ec23-4204-80ae-cf2f671a567c";
        public string User2Guid = "ecc226c3-124e-4f7d-a3db-b1c67bebb3b8";

        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<UsersToTagsContext>();
            builder.UseInMemoryDatabase("unit_testing");
            var contest = new UsersToTagsContext(builder.Options);

            Context = contest;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
