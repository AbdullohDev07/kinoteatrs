using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IConfiguration _configuration;

        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Person> GetPersons()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    return connection.Query<Person>("select * from persons").ToList();
                }
            }
            catch 
            { 
                return new List<Person>();
            }
        }

        public List<Person> GetIdPerson(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    return connection.Query<Person>($"select * from persons where id = {id}").ToList();
                }
            }
            catch
            {
                return new List<Person>();
            }
        }

        public PersonTDO InsertPerson(PersonTDO person)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Query<PersonTDO>($"insert into persons(name, age) values ('{person.name}', {person.age})").ToList();
                    return person;
                }
            }
            catch 
            {
                return new PersonTDO();
            }
        }

        public PersonTDO UpdatePerson(int id, PersonTDO person)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Query<PersonTDO>($"update persons set name = '{person.name}', age = {person.age} where id = {id}").ToList();
                    return person;
                }
            }
            catch 
            {
                return new PersonTDO();
            }
        }

        public int UpdatePatchPerson(int id, string name)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int num = connection.Execute($"update persons set name = @name where id = @id;", new { Id = id, Name = name });

                    return num;
                }
            }
            catch 
            {
                return -1;
            }
        }

        public int DeletePerson(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int x = connection.Execute($"delete from kinoteatr_cinema_person where person_id = @id;", new { Id = id });
                    int num = connection.Execute($"delete from persons where id = @id;", new { Id = id });

                    return num;
                }
            }
            catch 
            {
                return -1;
            }
        }
    }
}
