using MediatR;
using System;

namespace Application.Commands
{
    public class CreatePersonCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}