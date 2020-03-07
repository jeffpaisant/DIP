using Soat.CleanCoders.DipKata.Sender;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Soat.CleanCoders.DipKata.Tests
{
    public class SmsSenderShould
    {

        [Fact]
        public void Send_Sms_When_Called()
        {
            var sender = new SmsSender();

            sender.Send("plouf");
        }

    }
}
