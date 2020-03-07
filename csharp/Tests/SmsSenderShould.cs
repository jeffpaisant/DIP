using FluentAssertions;
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
        public void Send_Sms_When_Called()
        {
            var friend = "Joe";
            var expected = $"Happy birthday, my dear {friend}!";

            var sender = new SmsSender();

            sender.Send(friend);

            SmsBuffer.Should().Be(expected);
        }
    }
}
