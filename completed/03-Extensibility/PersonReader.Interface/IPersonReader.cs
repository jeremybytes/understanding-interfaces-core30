using System.Collections.Generic;

namespace PersonReader.Interface
{
    public interface IPersonReader
    {
        IReadOnlyCollection<Person> GetPeople();
        Person GetPerson(int id);
    }
}
