using FluentAssertions;
using Soat.CleanCoders.DipKata.FriendRepository;
using Xunit;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class FriendsLoaderShould
    {
        [Fact]
        public void After_Loading_Friends_List_Shoud_Not_Be_Empty()
        {
            var loader = new FriendsLoader();
            loader.Load();
            var friends = loader.GetFriends();

            friends.Should().NotBeEmpty();
        }

        [Fact]
        public void Beforer_Loading_Friends_List_Shoud_Be_Empty()
        {
            var loader = new FriendsLoader();
            var friends = loader.GetFriends();

            friends.Should().BeEmpty();
        }
    }
}
