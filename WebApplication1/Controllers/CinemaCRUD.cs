using Microsoft.AspNetCore.Mvc;
using Dapper;
using Npgsql;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CinemaCRUD : ControllerBase
    {
        public string connectionString = "Server=localhost;Port=16172;Database=api4;username=postgres;Password=axihub;";

        [HttpGet]
        public List<Cinema> GetCinemas()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return connection.Query<Cinema>("select * from cinemas").ToList();
            }
        }

        [HttpGet]
        public List<Cinema> GetIdCinema(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return connection.Query<Cinema>($"select * from cinemas where cinama_id = {id}").ToList();
            }
        }

        [HttpPost]
        public CinemaTDO InsertCinema(CinemaTDO cinema)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Query<CinemaTDO>($"insert into cinemas(name, price) values ('{cinema.name}', {cinema.price})").ToList();
                return cinema;
            }
        }

        [HttpPut]
        public CinemaTDO UpdateCinema(int id, CinemaTDO cinema)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Query<CinemaTDO>($"update cinemas set name = '{cinema.name}', price = {cinema.price} where cinama_id = {id}").ToList();
                return cinema;
            }
        }

        [HttpPatch]
        public int UpdatePatchCinema(int id, string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                int num = connection.Execute($"update cinemas set name = @name where cinama_id = @id;", new { Id = id, Name = name });

                return num;
            }
        }

        [HttpDelete]
        public int DeleteCinema(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                int x = connection.Execute($"delete from kinoteatr_cinema_person where cinema_id = @id;", new { Id = id });
                int num = connection.Execute($"delete from cinemas where cinama_id = @id;", new { Id = id });

                return num;
            }
        }
    }
}
