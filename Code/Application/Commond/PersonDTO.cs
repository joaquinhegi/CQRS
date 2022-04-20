using Application.Interfaces.Query;
using System;

namespace Application.Commond
{
    public class PersonDTO:IResult
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} birth {DateOfBirth}";
        }
    }
}