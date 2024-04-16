using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public class KinoteatrRepository : IKinoteatrRepository
    {
        private readonly IConfiguration _configuration;

        public KinoteatrRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Kinoteatr> GetKinoteatrs()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    return connection.Query<Kinoteatr>("select * from kinoteatrs").ToList();
                }
            }
            catch
            {
                return new List<Kinoteatr>();
            }
        }

        public List<Kinoteatr> GetIdKinoteatr(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    return connection.Query<Kinoteatr>($"select * from kinoteatrs where kinoteatr_id = {id}").ToList();
                }
            }
            catch
            {
                return new List<Kinoteatr>();
            }
        }

        public KinoteatrTDO InsertKinoteatr(KinoteatrTDO kinoteatr)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Query<KinoteatrTDO>($"insert into kinoteatrs(name) values ('{kinoteatr.name}')").ToList();
                    return kinoteatr;
                }
            }
            catch
            {
                return new KinoteatrTDO();
            }
        }

        public KinoteatrTDO UpdateKinoteatr(int id, KinoteatrTDO kinoteatr)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Query<KinoteatrTDO>($"update kinoteatrs set name = '{kinoteatr.name}' where kinoteatr_id = {id}").ToList();
                    return kinoteatr;
                }
            }
            catch
            {
                return new KinoteatrTDO();
            }
        }

        public int UpdatePatchKinoteatr(int id, string name)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int num = connection.Execute($"update kinoteatrs set name = @name where kinoteatr_id = @id;", new { Id = id, Name = name });

                    return num;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int DeleteKinoteatr(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int x = connection.Execute($"delete from kinoteatr_cinema_person where kinoteatr_id = @id;", new { Id = id });
                    int num = connection.Execute($"delete from kinoteatrs where kinoteatr_id = @id;", new { Id = id });

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
