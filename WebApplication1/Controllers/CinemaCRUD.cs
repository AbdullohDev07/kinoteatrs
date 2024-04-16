using Microsoft.AspNetCore.Mvc;
using Dapper;
using Npgsql;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;
using WebApplication1.MyPattern;
using WebApplication1.Services.IService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CinemaCRUD : ControllerBase
    {
        public ICinemaService _cinem;

        public CinemaCRUD (ICinemaService c)
        {
            _cinem = c;
        }

        [HttpGet]
        public IActionResult GetCinemas()
        {
            return Ok(_cinem.GetCinemas());
        }

        [HttpGet]
        public List<CinemaTDO> GetIdCinema(int id)
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
