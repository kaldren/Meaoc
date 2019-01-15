using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos;
using Meaoc_API.Meaoc_API.Test.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meaoc_API.Meaoc_API.Test.Controllers
{
    [TestClass]
    public class MessagesControllerTests
    {
        private readonly IMapper _mapper;

        [TestMethod]
        public void ShouldGetAllUserMessagesReceived()
        {
            var options = new DbContextOptionsBuilder<MeaocContext>()
                .UseInMemoryDatabase(databaseName: "Messages")
                .Options;

            using (var context = new MeaocContext(options))
            {
                context.Messages.Add(new Message
                {
                    Id = 1,
                    Content = "Hello from my first unit test",
                    DateSent = DateTime.Now,
                    AuthorId = 2,
                    RecipientId = 5,
                });
                context.Messages.Add(new Message
                {
                    Id = 2,
                    Content = "Hello from my second unit test",
                    DateSent = DateTime.Now,
                    AuthorId = 2,
                    RecipientId = 25,
                });
                context.Messages.Add(new Message
                {
                    Id = 3,
                    Content = "Hello from my third unit test",
                    DateSent = DateTime.Now,
                    AuthorId = 2,
                    RecipientId = 445,
                });
                context.SaveChanges();
            }

            using (var context = new MeaocContext(options))
            {
                var service = new MessageService(context, _mapper);
                var allMessages = service.GetAllUserMessagesReceived(5);
                Assert.IsNotNull(allMessages);
            }
        }
    }
}
