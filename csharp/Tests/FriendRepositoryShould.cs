using FluentAssertions;
using Moq;
using Soat.CleanCoders.DipKata.Repository;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void Return_Friends_When_Friends_Found()
        {
            var now = DateTime.Now;
            var loader = new Mock<ILoader>();
            loader.Setup(r => r.GetFriends()).Returns(
                new List<StoredFriend> {
                    new StoredFriend()
                    {
                        first_name="john",
                        last_name="doe",
                        date_of_birth= now.ToString(),
                        email= "mail"
                    }
                });

            var repository = new FriendRepository(loader.Object);

            var friends = repository.FindFriendsBornOn(now);

            friends.Should().NotBeEmpty();
        }
    }
}
