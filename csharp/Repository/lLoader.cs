using System.Collections.Generic;

namespace Soat.CleanCoders.DipKata.Repository
{
    public interface ILoader
    {
        void Load();
        IEnumerable<StoredFriend> GetFriends();
    }
}