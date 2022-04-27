using System;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Infrastructure.Repository;
using Application.Commands;
using Application.Commands.DeletePerson;
using Application.Queries;
using Application.Queries.GetPersonBetweenYear;
using Application.Commond;
using MediatR;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var mediator = BuildMediator();

                //Add new Person
                var addPerson = new CreatePersonCommand { Id = 7, FirstName = "Daiana", LastName = "Fernandez", DateOfBirth = new DateTime(1995, 11, 21) };
                mediator.Send(addPerson);

                //Query Person by ID
                var queryPerson = new FindPersonByIdCommand { Id = 7 };
                var result = mediator.Send(queryPerson);
                Console.WriteLine(result.Result?.ToString());

                //Delere Person
                var deletePerson = new DeletePersonCommand { Id = 7 };
                mediator.Send(deletePerson);

                //Query Person by Name
                var querybetweenPerson = new FindPersonBetweenYearCommand { StartYear = 1980, EndYear = 1995 };
                var resultBetween = mediator.Send(querybetweenPerson);
                foreach (PersonDTO person in resultBetween.Result)
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

        private static IMediator BuildMediator()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRepository, Repository>();
            services.AddMediatR(new Type[] { typeof(CreatePersonCommand),
            typeof(DeletePersonCommand),
            typeof(FindPersonBetweenYearCommand),
            typeof(FindPersonByIdCommand)
            });

            var provider = services.BuildServiceProvider();
            return provider.GetRequiredService<IMediator>();
        }
    }
}
