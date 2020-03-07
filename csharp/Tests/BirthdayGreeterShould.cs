using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Moq;
using Soat.CleanCoders.DipKata.Main;
using Soat.CleanCoders.DipKata.Sender;
using Xunit;
using static Soat.CleanCoders.DipKata.Main.FriendBuilder;
using Soat.CleanCoders.DipKata.Main.Interfaces;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class BirthdayGreeterShould
    {
        private readonly BirthdayGreeter _birthdayMailGreeter;
        private readonly BirthdayGreeter _birthdaySMSGreeter;
        private readonly TextWriter _consoleOutput;
        private readonly Mock<IFriendRepository> _friendRepositoryMock;

        private string MailBuffer => _consoleOutput.ToString();

        public BirthdayGreeterShould()
        {
            _friendRepositoryMock = new Mock<IFriendRepository>();
            _birthdayMailGreeter = new BirthdayGreeter(_friendRepositoryMock.Object, new EmailSender());
            _birthdaySMSGreeter = new BirthdayGreeter(_friendRepositoryMock.Object, new SmsSender());
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [Fact]
        public void Send_greeting_email_to_the_friend_born_today()
        {
            // Arrange
            var friend = AFriend().Build();

            _friendRepositoryMock
                .Setup(x => x.FindFriendsBornOn(It.IsAny<DateTime>()))
                .Returns(new[] { friend });

            // Act
            _birthdayMailGreeter.SendGreetings();

            // Assert
            var expectedMailContent =
                $"To:{friend.Email}, Subject: Happy birthday!, " +
                $"Message: Happy birthday, dear {friend.FirstName}!";

            MailBuffer.Should().Be(expectedMailContent);
        }

        [Fact]
        public void Send_no_greeting_email_when_its_nobody_birthday()
        {
            _friendRepositoryMock
                .Setup(x => x.FindFriendsBornOn(It.IsAny<DateTime>()))
                .Returns(Enumerable.Empty<Friend>());

            _birthdayMailGreeter.SendGreetings();

            MailBuffer.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Send_greeting_SMS_to_the_friend_born_today()
        {
            // Arrange
            var friend = AFriend().Build();

            _friendRepositoryMock
                .Setup(x => x.FindFriendsBornOn(It.IsAny<DateTime>()))
                .Returns(new[] { friend });

            // Act
            _birthdaySMSGreeter.SendGreetings();

            // Assert
            var expectedMailContent = $"SMS: Happy birthday, dear {friend.FirstName}!";

            MailBuffer.Should().Be(expectedMailContent);
        }

        [Fact]
        public void Send_no_greeting_SMS_when_its_nobody_birthday()
        {
            _friendRepositoryMock
                .Setup(x => x.FindFriendsBornOn(It.IsAny<DateTime>()))
                .Returns(Enumerable.Empty<Friend>());

            _birthdaySMSGreeter.SendGreetings();

            MailBuffer.Should().BeNullOrEmpty();
        }
    }
}
