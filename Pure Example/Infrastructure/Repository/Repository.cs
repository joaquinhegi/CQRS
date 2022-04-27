using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    public class Repository: IRepository
    {
        private List<Person> _persons;
        public Repository()
        {
            _persons = new List<Person>()
            {
                new Person { Id = 1, FirstName = "Roberto", LastName = "Gonzales", DateOfBirth = new DateTime(1987,2,20) },
                new Person { Id = 2, FirstName = "Jose", LastName = "Diaz", DateOfBirth = new DateTime(1990,5,1) },
                new Person { Id = 3, FirstName = "Marta", LastName = "Perez", DateOfBirth = new DateTime(2000, 3, 15) },
                new Person { Id = 4, FirstName = "Marcela", LastName = "Gonzales", DateOfBirth = new DateTime(1987, 9, 25) },
                new Person { Id = 5, FirstName = "Andres", LastName = "Ponce", DateOfBirth = new DateTime(1989, 12, 15) },
                new Person { Id = 6, FirstName = "Lucia", LastName = "Ledesma", DateOfBirth = new DateTime(1989, 10, 2) },
            };
        }

        public IList<Person> Persons
        { 
            get => _persons; 
            set => _persons = (List<Person>)value; 
        }
    }
}