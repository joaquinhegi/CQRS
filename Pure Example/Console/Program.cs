using System;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastructure.Repository;
using Application.Commands;
using Application.Commands.CreatePerson;
using Application.Commands.DeletePerson;
using Application.Interfaces.Command;
using Application.Queries;
using Application.Interfaces.Query;
using Application.Queries.FindPersonBetweenYear;
using Application.Queries.FindPersonById;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();

            try
            {
                var commandDispatcher = new CommandDispatcher(serviceProvider);
                var queryDispatcher = new QueryDispatcher(serviceProvider);

                //Add new Person
                var addPerson = new CreatePersonCommand { Id = 7, FirstName = "Daiana", LastName = "Fernandez", DateOfBirth = new DateTime(1995, 11, 21) };
                commandDispatcher.Send(addPerson);

                //Query Person by ID
                var queryPerson = new FindPersonByIdCommand { Id = 7 };
                var result = queryDispatcher.Send(queryPerson);
                foreach (IResult person in result.Result)
                {
                    Console.WriteLine(person.ToString());
                }

                //Delere Person
                var deletePerson = new DeletePersonCommand { Id = 7 };
                commandDispatcher.Send(deletePerson);

                //Query Person by Name
                var querybetweenPerson = new FindPersonBetweenYearCommand { StartYear = 1980, EndYear = 1995 };
                var resultBetween = queryDispatcher.Send(querybetweenPerson);
                foreach (IResult person in resultBetween.Result)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        private static IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                    // Add data base context
                    .AddSingleton<IRepository, Repository>()
                    // Add commands handlers
                    .AddScoped<ICommandHandler<CreatePersonCommand>, CreatePersonCommandHandler>()
                    .AddScoped<ICommandHandler<DeletePersonCommand>, DeletePersonCommandHandler>()
                    // Add Query handlers
                    .AddScoped<IQueryHandler<FindPersonByIdCommand>, FindPersonByIdCommandHandler>()
                    .AddScoped<IQueryHandler<FindPersonBetweenYearCommand>, FindPersonBetweenYearCommandHandler>()
                    //Creat service
                    .BuildServiceProvider();
        }
    }
}
