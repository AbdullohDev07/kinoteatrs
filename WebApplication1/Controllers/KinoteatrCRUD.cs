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
    public class KinoteatrCRUD : ControllerBase
    {
        public string connectionString = "Server=localhost;Port=16172;Database=api4;username=postgres;Password=axihub;";

        [HttpGet]
        public List<Kinoteatr> GetKinoteatrs()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return connection.Query<Kinoteatr>("select * from kinoteatrs").ToList();
            }
        }

        [HttpGet]
        public List<Kinoteatr> GetIdKinoteatr(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                return connection.Query<Kinoteatr>($"select * from kinoteatrs where kinoteatr_id = {id}").ToList();
            }
        }

        [HttpPost]
        public KinoteatrTDO InsertKinoteatr(KinoteatrTDO kinoteatr)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Query<KinoteatrTDO>($"insert into kinoteatrs(name) values ('{kinoteatr.name}')").ToList();
                return kinoteatr;
            }
        }

        [HttpPut]
        public KinoteatrTDO UpdateKinoteatr(int id, KinoteatrTDO kinoteatr)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Query<KinoteatrTDO>($"update kinoteatrs set name = '{kinoteatr.name}' where kinoteatr_id = {id}").ToList();
                return kinoteatr;
            }
        }

        [HttpPatch]
        public int UpdatePatchKinoteatr(int id, string name)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                int num = connection.Execute($"update kinoteatrs set name = @name where kinoteatr_id = @id;", new { Id = id, Name = name });

                return num;
            }
        }

        [HttpDelete]
        public int DeleteKinoteatr(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                int x = connection.Execute($"delete from kinoteatr_cinema_person where kinoteatr_id = @id;", new { Id = id });
                int num = connection.Execute($"delete from kinoteatrs where id = @id;", new { Id = id });

                return num;
            }
        }
    }
}
