using Application.Commond;
using Application.Interfaces;
using Application.Queries;
using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using System.Threading.Tasks;
using Application.Queries.FindPersonBetweenYear;
using Application.Queries.FindPersonById;
using Xunit;

namespace Aplication.Test
{
    public class QueryTest
    {
        private readonly Mock<IRepository> _mockRepo;

        public QueryTest()
        {
            _mockRepo = MockPersonRepository.GetPersonsRespository();
        }

        [Fact]
        public async Task TestFindPersonBetweenYearCommandHandler()
        {

            var handler = new FindPersonBetweenYearCommandHandler(_mockRepo.Object);
            var querybetweenPerson = new FindPersonBetweenYearCommand { StartYear = 1980, EndYear = 1995 };

            var result = await handler.Handle(querybetweenPerson);

            result.Should().HaveCount(5);
        }

        [Fact]
        public async Task TestFindPersonByIdCommandHandler()
        {

            var handler = new FindPersonByIdCommandHandler(_mockRepo.Object);
            var querybetweenPerson = new FindPersonByIdCommand { Id = 1 };

            var result = await handler.Handle(querybetweenPerson);

            result.Should().HaveCount(1);
            ((PersonDTO)result[0]).FirstName.Should().Be("Roberto");
            ((PersonDTO)result[0]).LastName.Should().Be("Gonzales");
            ((PersonDTO)result[0]).DateOfBirth.Should().Be(20.February(1987));
        }

        [Fact]
        public async Task TestFindPersonByIdCommandHandlerResultNull()
        {

            var handler = new FindPersonByIdCommandHandler(_mockRepo.Object);
            var querybetweenPerson = new FindPersonByIdCommand { Id = 10 };

            var result = await handler.Handle(querybetweenPerson);

            result.Should().BeNull();
        }
    }
}