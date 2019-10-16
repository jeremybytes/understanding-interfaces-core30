using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common
{
    public interface IPersonReader
    {
        IReadOnlyCollection<Person> GetPeople();
        Person GetPerson(int id);
    }
}
