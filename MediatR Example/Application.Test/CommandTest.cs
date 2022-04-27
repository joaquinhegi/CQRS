using Application.Commands;
using Application.Commands.DeletePerson;
using Application.Commond;
using Application.Interfaces;
using Application.Queries.GetPersonBetweenYear;
using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test
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

            var result = await handler.Handle(createPersonCommand, CancellationToken.None);
           
            result.Should().Be(7);
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

            var result = await handler.Handle(deletePersonCommand, CancellationToken.None);

            result.Should().Be(6);
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

           var a = await handler.Invoking(y => y.Handle(deletePersonCommand, CancellationToken.None))
                .Should()
                .ThrowAsync<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'The person with id does not exist:100')");

        }
    }
}
