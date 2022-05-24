using Application.Interfaces.Query;
using System;

namespace Application.Commond
{
    public class PersonDTO:IResult
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} birth {DateOfBirth}";
        }
    }
}