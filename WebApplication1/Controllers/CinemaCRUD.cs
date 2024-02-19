using Microsoft.AspNetCore.Mvc;
using Dapper;
using Npgsql;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;
using WebApplication1.MyPattern;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CinemaCRUD : ControllerBase
    {
        public ICinemaRepository _cinem;

        public CinemaCRUD (ICinemaRepository c)
        {
            _cinem = c;
        }

        [HttpGet]
        public List<Cinema> GetCinemas()
        {
            return _cinem.GetCinemas();
        }

        [HttpGet]
        public List<Cinema> GetIdCinema(int id)
        {
           return _cinem.GetIdCinema(id);
        }

        [HttpPost]
        public CinemaTDO InsertCinema(CinemaTDO cinema)
        {
            return _cinem.InsertCinema(cinema);
        }

        [HttpPut]
        public CinemaTDO UpdateCinema(int id, CinemaTDO cinema)
        {
            return _cinem.UpdateCinema(id, cinema);
        }

        [HttpPatch]
        public int UpdatePatchCinema(int id, string name)
        {
            return _cinem.UpdatePatchCinema(id, name);
        }

        [HttpDelete]
        public int DeleteCinema(int id)
        {
            return _cinem.DeleteCinema(id);
        }
    }
}
