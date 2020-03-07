using FluentAssertions;
using Soat.CleanCoders.DipKata.Main;
using Soat.CleanCoders.DipKata.Sender;
using System;
using System.IO;
using Xunit;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class SmsSenderShould
    {
        private TextWriter _consoleOutput;

        private string SmsBuffer => _consoleOutput.ToString();

        public SmsSenderShould()
        {
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [Fact]
        public void Send_Sms_ToAFriend()
        {
            var friendBuilder = new FriendBuilder();
            var friend = friendBuilder.WithFirstName("Joe").Build();
            var sender = new SmsSender();
            var expected = $"SMS: Happy birthday, my dear {friend.FirstName}!";
            var message = $"Happy birthday, my dear {friend.FirstName}!";

            sender.Send(friend, message);

            SmsBuffer.Should().Be(expected);
        }
    }
}
