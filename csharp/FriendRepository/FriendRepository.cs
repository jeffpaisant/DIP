using System;
using System.Collections.Generic;

namespace Soat.CleanCoders.DipKata.Main
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> FindFriendsBornOn(DateTime today);
    }
}
