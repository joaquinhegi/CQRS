using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepository
    {
        IList<Person> Persons { get; set; }
    }
}