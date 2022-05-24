using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepository
    {
       public IList<Person> Persons { get; }
    }
}