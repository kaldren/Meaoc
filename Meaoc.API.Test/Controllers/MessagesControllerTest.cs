using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Meaoc.API.Test.Controllers
{
    class MessagesControllerTest
    {
        public MessagesControllerTest()
        {

        }

        [Fact]
        public int ShouldReturnAllUserMessagesReceivedById()
        {
            var messages = GetAllUserMessagesReceived(1);
        }
    }
}
