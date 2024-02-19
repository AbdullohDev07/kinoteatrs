using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Npgsql;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly IConfiguration _configuration;

        public CinemaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cinema> GetCinemas()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    return connection.Query<Cinema>("select * from cinemas").ToList();
                }
            }
            catch
            { 
                return new List<Cinema>();
            }
        }

        public List<Cinema> GetIdCinema(int id)
        {
            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    return connection.Query<Cinema>($"select * from cinemas where cinama_id = {id}").ToList();
                } 
            }
            catch 
            {
                return new List<Cinema>();
            }
        }

        public CinemaTDO InsertCinema(CinemaTDO cinema)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Query<CinemaTDO>($"insert into cinemas(name, price) values ('{cinema.name}', {cinema.price})").ToList();
                    return cinema;
                }
            }
            catch
            {
                return new CinemaTDO();
            }
        }

        public CinemaTDO UpdateCinema(int id, CinemaTDO cinema)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Query<CinemaTDO>($"update cinemas set name = '{cinema.name}', price = {cinema.price} where cinama_id = {id}").ToList();
                    return cinema;
                }
            }
            catch
            {
                return new CinemaTDO();
            }
        }

        public int UpdatePatchCinema(int id, string name)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int num = connection.Execute($"update cinemas set name = @name where cinama_id = @id;", new { Id = id, Name = name });

                    return num;
                }
            }
            catch
            {
                return -1;
            }
        }

        public int DeleteCinema(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int x = connection.Execute($"delete from kinoteatr_cinema_person where cinema_id = @id;", new { Id = id });
                    int num = connection.Execute($"delete from cinemas where cinama_id = @id;", new { Id = id });

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
