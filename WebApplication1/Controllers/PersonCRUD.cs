using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Dapper;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;
using WebApplication1.MyPattern;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonCRUD : ControllerBase
    {
        public IPersonRepository _per;

        public PersonCRUD(IPersonRepository per) 
        {
            _per = per;
        }

        [HttpGet]
        public List<Person> GetPersons()
        {
            return _per.GetPersons();
        }

        [HttpGet]
        public List<Person> GetIdPerson(int id)
        {
            return _per.GetIdPerson(id);
        }

        [HttpPost]
        public PersonTDO InsertPerson(PersonTDO person)
        {
            return _per.InsertPerson(person);
        }

        [HttpPut]
        public PersonTDO UpdatePerson(int id, PersonTDO person)
        {
            return _per.UpdatePerson(id, person);
        }

        [HttpPatch]
        public int UpdatePatchPerson(int id, string name)
        {
            return _per.UpdatePatchPerson(id, name);
        }

        [HttpDelete]
        public int DeletePerson(int id)
        {
            return _per.DeletePerson(id);
        }
    }
}
