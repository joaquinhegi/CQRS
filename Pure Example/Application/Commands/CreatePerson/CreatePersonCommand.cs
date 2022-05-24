using System;
using Application.Interfaces;

namespace Application.Commands.CreatePerson
{
    public class CreatePersonCommand:ICommand
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}