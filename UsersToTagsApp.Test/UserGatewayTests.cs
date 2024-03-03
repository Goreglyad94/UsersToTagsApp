using UsersToTagsApp.Core.DataGateways;
using UsersToTagsApp.Test.Infrastructure.Builders;
using UsersToTagsApp.Test.Infrastructure.Helper;

namespace UsersToTagsApp.Test
{
    public class UserGatewayTests
    {
        private UserBuilder _userBuilder;
        private TagBuilder _tagBuilder;

        [SetUp]
        public void Setup()
        {
            _userBuilder = new UserBuilder();
            _tagBuilder = new TagBuilder();
        }

        [Test]
        public async Task WhenGettingUserByGuid_ThenReturnUserWithTags()
        {
            using (var contextHelper = new DbContextHelper())
            {
                var userGateway = new UserGateway(contextHelper.Context);

                var userId1 = Guid.NewGuid();
                var userId2 = Guid.NewGuid();

                var userDomain1 = "TestDomain1";

                var user1 = _userBuilder.CreateUser(userId1, "TestName1", userDomain1);
                var user2 = _userBuilder.CreateUser(userId2, "TestName2", userDomain1);

                var tag1 = _tagBuilder.CreateTag("TestValue1", "TestDomain1");
                var tag2 = _tagBuilder.CreateTag("TestValue2", "TestDomain2");

                user1.AddTag(tag1);
                user1.AddTag(tag2);
                user2.AddTag(tag2);

                contextHelper.Context.Users.Add(user1);
                contextHelper.Context.Users.Add(user2);

                contextHelper.Context.SaveChanges();

                var user = await userGateway.GetByIdAndDomain(userId1, userDomain1);

                Assert.IsNotNull(user);
                Assert.IsTrue(user.Tags.Count == 2);
            }
        }
    }
}