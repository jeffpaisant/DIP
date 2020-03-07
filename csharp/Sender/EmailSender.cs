﻿using Soat.CleanCoders.DipKata.Main;
using System;

namespace Soat.CleanCoders.DipKata.Sender
{
    public class EmailSender : ISender
    {
        private string _emailAddress;

        private void SendMail(string message)
        {
            Send(_emailAddress, message);
        }

        private void Send(string emailAddress, string message)
        {
            Console.Write($"To:{emailAddress}, Subject: Happy birthday!, Message: {message}");
        }

        public void Send(Friend friend, string message)
        {
            _emailAddress = friend.Email;
            SendMail(message);
        }
    }
}
