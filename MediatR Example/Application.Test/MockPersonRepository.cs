using Application.Interfaces;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test
{
    public static class MockPersonRepository
    {
        public static Mock<IRepository> GetPersonsRespository() 
        {
             var persons = new List<Person>()
            {
                new Person { Id = 1, FirstName = "Roberto", LastName = "Gonzales", DateOfBirth = new DateTime(1987,2,20) },
                new Person { Id = 2, FirstName = "Jose", LastName = "Diaz", DateOfBirth = new DateTime(1990,5,1) },
                new Person { Id = 3, FirstName = "Marta", LastName = "Perez", DateOfBirth = new DateTime(2000, 3, 15) },
                new Person { Id = 4, FirstName = "Marcela", LastName = "Gonzales", DateOfBirth = new DateTime(1987, 9, 25) },
                new Person { Id = 5, FirstName = "Andres", LastName = "Ponce", DateOfBirth = new DateTime(1989, 12, 15) },
                new Person { Id = 6, FirstName = "Lucia", LastName = "Ledesma", DateOfBirth = new DateTime(1989, 10, 2) },
            };

            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(x => x.Persons).Returns(persons);

            return mockRepo;
        }
    }
}
