using FluentAssertions;
using Soat.CleanCoders.DipKata.Repository.LowLevelLoader;
using Xunit;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class FriendsLoaderShould
    {
        private string _fileName = "D:\\Repository\\DIP\\csharp\\Repository\\Physical\\PhysicalRepository.json";

        [Fact]
        public void After_Loading_Friends_List_Shoud_Not_Be_Empty()
        {
            var loader = LoaderFactory.GetLoader(_fileName);
            loader.Load();
            var friends = loader.GetFriends();

            friends.Should().NotBeEmpty();
        }

        [Fact]
        public void Beforer_Loading_Friends_List_Shoud_Be_Empty()
        {
            var loader = LoaderFactory.GetLoader(_fileName);
            var friends = loader.GetFriends();

            friends.Should().BeEmpty();
        }
    }
}
