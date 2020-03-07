using FluentAssertions;
using Moq;
using Soat.CleanCoders.DipKata.Repository;
using System;
using System.Linq;
using Xunit;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class FriendRepositoryShould
    {
        [Fact]
        public void Return_An_Empty_List_When_No_Friends()
        {
            var loader = new Mock<ILoader>();
            loader.Setup(r => r.GetFriends()).Returns(Enumerable.Empty<StoredFriend>());

            var repository = new FriendRepository(loader.Object);

            var friends = repository.FindFriendsBornOn(DateTime.Now);

            friends.Should().BeEmpty();
        }

    }
}
