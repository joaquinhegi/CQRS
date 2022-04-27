using Application.Commands;
using Application.Commands.DeletePerson;
using Application.Interfaces;
using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Aplication.Test
{
    public class CommandTest
    {
        private readonly Mock<IRepository> _mockRepo;

        public CommandTest()
        {
            _mockRepo = MockPersonRepository.GetPersonsRespository();
        }

        [Fact]
        public async Task TestCreatePersonCommandHandler()
        {
            var handler = new CreatePersonCommandHandler(_mockRepo.Object);
            var createPersonCommand = new CreatePersonCommand
            {
                Id = 7,
                FirstName = "Daiana",
                LastName = "Fernandez",
                DateOfBirth = 21.November(1995)
            };

            await handler.Handle(createPersonCommand);

            _mockRepo.Object.Persons.Should().HaveCount(7);
        }

        [Fact]
        public async Task TestDeletePersonCommandHandler()
        {

            var handler = new DeletePersonCommandHandler(_mockRepo.Object);
            var deletePersonCommand = new DeletePersonCommand
            {
                Id = 6
            };

            await handler.Handle(deletePersonCommand);

            _mockRepo.Object.Persons.Should().HaveCount(5);
        }

        [Fact]
        public async Task TestDeletePersonCommandHandlerArgumentNullException()
        {

            var handler = new DeletePersonCommandHandler(_mockRepo.Object);
            var deletePersonCommand = new DeletePersonCommand
            {
                Id = 100
            };

            await handler.Invoking(y => y.Handle(deletePersonCommand))
                 .Should()
                 .ThrowAsync<ArgumentNullException>()
                 .WithMessage("Value cannot be null. (Parameter 'The person with id does not exist:100')");

        }

    }
}
