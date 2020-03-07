using System;
using System.IO;
using FluentAssertions;
using Soat.CleanCoders.DipKata.Main;
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
        public void SendMessage_When_Called()
        {
            var sender = new EmailSender();
            var mail = "myEmail";
            var message = "myWonderfulMessage";
            var expected = $"To:{mail}, Subject: Happy birthday!, Message: {message}";

            sender.Send(mail, message);

            MailBuffer.Should().Be(expected);
        }

        [Fact]
        public void SendMessage_From_PrivateAddress_When_Called()
        {
            var sender = new EmailSender();
            var message = "myWonderfulMessage";
            var expected = $"To:, Subject: Happy birthday!, Message: {message}";

            sender.Send(message);

            MailBuffer.Should().Be(expected);
        }
    }
}
