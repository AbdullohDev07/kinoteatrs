using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public interface IPersonRepository
    {
        public List<Person> GetPersons();
        public List<Person> GetIdPerson(int id);
        public PersonTDO InsertPerson(PersonTDO person);
        public PersonTDO UpdatePerson(int id, PersonTDO person);
        public int UpdatePatchPerson(int id, string name);
        public int DeletePerson(int id);
    }
}
