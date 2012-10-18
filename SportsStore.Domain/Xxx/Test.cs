using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Xxx
{

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }

    internal interface IUow
    {
        void Commit();

        void Submit();
    }

    internal interface IRepository<T> where T:new()
    {
        List<T> All();
    }

    public abstract class BaseUow:IUow
    {
        public BaseUow(/**/)
        {
            
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }

    public class PersonRepository : BaseUow,IRepository<Person>
    {
        public List<Person> All()
        {
            /*
             * Implementacja pobierania listy
             */
            throw new NotImplementedException();
        }
    }
}