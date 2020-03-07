using Soat.CleanCoders.DipKata.Main;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Soat.CleanCoders.DipKata.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private ILoader _loader;
        private IEnumerable<Friend> _friends;

        public FriendRepository(ILoader loader)
        {
            _loader = loader;
        }

        public IEnumerable<Friend> FindFriendsBornOn(DateTime dayOfBirth)
        {
            _friends = GetFriends();
            return _friends.Where(f => f.DateOfBirth == dayOfBirth);
        }

        private IEnumerable<Friend> GetFriends()
        {
            _loader.Load();
            var storedFriends = _loader.GetFriends();
            var friends = new List<Friend>();
            foreach (var sf in storedFriends)
            {
                var dob = DateTime.Parse(sf.date_of_birth);
                var friend = MapStoredFriendToFriend(sf, dob);
                friends.Add(friend);
            }
            return friends;
        }

        private static Friend MapStoredFriendToFriend(StoredFriend sf, DateTime dob)
        {
            var builder = new FriendBuilder();
            var friend = builder.WithFirstName(sf.first_name)
                .WithLastName(sf.last_name)
                .WithEmail(sf.email)
                .WithDateOfBirth(dob).Build();
            return friend;
        }
    }
}
