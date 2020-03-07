using Newtonsoft.Json;
using Soat.CleanCoders.DipKata.Repository;
using System.Collections.Generic;
using System.IO;

namespace Soat.CleanCoders.DipKata.Repository
{
    public class FriendsLoader : ILoader
    {
        IEnumerable<StoredFriend> _friends = new List<StoredFriend>();

        public IEnumerable<StoredFriend> GetFriends() => _friends;

        public void Load()
        {
            LoadFromJsonFile("D:\\Repository\\DIP\\csharp\\FriendRepository\\PhysicalRepository.json");
        }

        private void LoadFromJsonFile(string fileName)
        {
            var myFileString = File.ReadAllText(fileName);
            _friends = JsonConvert.DeserializeObject<IEnumerable<StoredFriend>>(myFileString);
        }
    }
}
