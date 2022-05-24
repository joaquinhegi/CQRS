using System;

namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init;}
        public DateTime DateOfBirth { get; init; }
    }
}
