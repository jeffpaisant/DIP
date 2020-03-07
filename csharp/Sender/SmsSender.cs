using Soat.CleanCoders.DipKata.Main;
using System;

namespace Soat.CleanCoders.DipKata.Sender
{
    public class SmsSender : ISender
    {
        public void Send(string friendName)
        {
            Console.Write($"Happy birthday, my dear {friendName}!");
        }

        public void Send(Friend friend, string message)
        {
            Send(friend.FirstName);
        }
    }
}
