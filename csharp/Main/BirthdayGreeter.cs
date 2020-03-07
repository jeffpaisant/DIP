using Soat.CleanCoders.DipKata.Sender;
using System;
using System.Linq;

namespace Soat.CleanCoders.DipKata.Main
{
    public class BirthdayGreeter
    {
        private readonly FriendRepository _friendRepository;
        private ISender _sender;

        public BirthdayGreeter(FriendRepository friendRepository, ISender sender)
        {
            _friendRepository = friendRepository;
            _sender = sender;
        }

        public void SendGreetings()
        {
            var today = DateTime.Now;
            _friendRepository.FindFriendsBornOn(today)
                             .ToList()
                             .ForEach(friend =>
                             {
                                 var message = MailMessageFor(friend);
                                 _sender.Send(friend, message);
                             });
        }

        private string MailMessageFor(Friend friend) =>
            $"Happy birthday, dear {friend.FirstName}!";
    }
}
