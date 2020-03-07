using System;
using System.IO;
using FluentAssertions;
using Soat.CleanCoders.DipKata.Main;
using Soat.CleanCoders.DipKata.Sender;
using Xunit;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class EmailSenderShould
    {
        private TextWriter _consoleOut;

        private string MailBuffer => _consoleOut.ToString();

        public EmailSenderShould()
        {
            _consoleOut = new StringWriter();
            Console.SetOut(_consoleOut);
        }

        [Fact]
        public void SendMessage_From_EmptyAddress_When_Called_Without_Address()
        {
            var sender = new EmailSender();
            var message = "myWonderfulMessage";
            var expected = $"To:, Subject: Happy birthday!, Message: {message}";

            sender.Send(message);

            MailBuffer.Should().Be(expected);
        }

        [Fact]
        public void SendMessage_to_Friend_Address()
        {
            var sender = new EmailSender();
            var message = "myWonderfulMessage";
            var friendBuilder = new FriendBuilder();
            var friend = friendBuilder.WithEmail("JoeAdress").Build();
            var expected = $"To:{friend.Email}, Subject: Happy birthday!, Message: {message}";

            sender.Send(friend, message);

            MailBuffer.Should().Be(expected);
        }
    }
}
