using Soat.CleanCoders.DipKata.Repository;
using Soat.CleanCoders.DipKata.Sender;
using System;

namespace Soat.CleanCoders.DipKata.Main
{
    public class BirthdayGreeter
    {
        private readonly IFriendRepository _friendRepository;
        private ISender _sender;

        public BirthdayGreeter(IFriendRepository friendRepository, ISender sender)
        {
            _friendRepository = friendRepository;
            _sender = sender;
        }

        public void SendGreetings()
        {
            var today = DateTime.Now;
            var friends = _friendRepository.FindFriendsBornOn(today);

            foreach (var friend in friends)
            {
                var message = MailMessageFor(friend);
                _sender.Send(friend, message);
            }
        }

        private string MailMessageFor(Friend friend) =>
            $"Happy birthday, dear {friend.FirstName}!";
    }
}
