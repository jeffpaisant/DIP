using System.Collections.Generic;

namespace Soat.CleanCoders.DipKata.Repository.LowLevelLoader
{
    public interface ILoader
    {
        void Load();
        IEnumerable<StoredFriend> GetFriends();
    }
}