using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Soat.CleanCoders.DipKata.Repository.LowLevelLoader
{
    public class JsonFriendsLoader : ILoader
    {
        private IEnumerable<StoredFriend> _friends = new List<StoredFriend>();
        private string _fileName;

        public JsonFriendsLoader(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<StoredFriend> GetFriends() => _friends;

        public void Load()
        {
            LoadFromJsonFile(_fileName);
        }

        private void LoadFromJsonFile(string fileName)
        {
            var myFileString = File.ReadAllText(fileName);
            _friends = JsonConvert.DeserializeObject<IEnumerable<StoredFriend>>(myFileString);
        }
    }
}
