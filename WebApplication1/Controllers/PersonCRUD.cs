using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Dapper;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonCRUD : ControllerBase
    {
        public string connectionString = "Server=localhost;Port=16172;Database=api4;username=postgres;Password=axihub;";

        [HttpGet]
        public List<Person> GetPersons()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return connection.Query<Person>("select * from persons").ToList();
            }
        }

        [HttpGet]
        public List<Person> GetIdPerson(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return connection.Query<Person>($"select * from persons where id = {id}").ToList();
            }
        }

        [HttpPost]
        public PersonTDO InsertPerson(PersonTDO person)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Query<PersonTDO>($"insert into persons(name, age) values ('{person.name}', {person.age})").ToList();
                return person;
            }
        }

        [HttpPut]
        public PersonTDO UpdatePerson(int id, PersonTDO person)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Query<PersonTDO>($"update persons set name = '{person.name}', age = {person.age} where id = {id}").ToList();
                return person;
            }
        }

        [HttpPatch]
        public int UpdatePatchPerson(int id, string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                int num = connection.Execute($"update persons set name = @name where id = @id;", new { Id = id, Name = name });

                return num;
            }
        }

        [HttpDelete]
        public int DeletePerson(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                int x = connection.Execute($"delete from kinoteatr_cinema_person where person_id = @id;", new { Id = id });
                int num = connection.Execute($"delete from persons where id = @id;", new { Id = id });

                return num;
            }
        }
    }
}
