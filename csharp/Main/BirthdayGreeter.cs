﻿using Soat.CleanCoders.DipKata.Sender;
using System;
using System.Linq;

namespace Soat.CleanCoders.DipKata.Main
{
    public class BirthdayGreeter
    {
        private readonly FriendRepository _friendRepository;

        public BirthdayGreeter(FriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public void SendGreetings()
        {
            var today       = DateTime.Now;
            var emailSender = new EmailSender();
            _friendRepository.FindFriendsBornOn(today)
                             .ToList()
                             .ForEach(friend =>
                             {
                                 var message = MailMessageFor(friend);
                                 emailSender.Send(friend.Email, message);
                             });
        }

        private string MailMessageFor(Friend friend) =>
            $"Happy birthday, dear {friend.FirstName}!";
    }
}
