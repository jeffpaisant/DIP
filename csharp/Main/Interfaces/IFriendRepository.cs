﻿using Soat.CleanCoders.DipKata.Main;
using System;
using System.Collections.Generic;

namespace Soat.CleanCoders.DipKata.Main.Interfaces
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> FindFriendsBornOn(DateTime today);
    }
}
