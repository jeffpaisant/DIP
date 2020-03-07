using Soat.CleanCoders.DipKata.Main;
using System;

namespace Soat.CleanCoders.DipKata.Sender
{
    public class SmsSender : ISender
    {
        public void Send(string message)
        {
            Console.Write($"Happy birthday!, Message: {message}");
        }
    }
}
