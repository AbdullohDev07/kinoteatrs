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
    public class KinoteatrCRUD : ControllerBase
    {
        public IKinoteatrRepository _kino;

        public KinoteatrCRUD (IKinoteatrRepository kino)
        {
            _kino = kino;
        }

        [HttpGet]
        public List<Kinoteatr> GetKinoteatrs()
        {
            return _kino.GetKinoteatrs();
        }

        [HttpGet]
        public List<Kinoteatr> GetIdKinoteatr(int id)
        {
            return _kino.GetIdKinoteatr(id);
        }

        [HttpPost]
        public KinoteatrTDO InsertKinoteatr(KinoteatrTDO kinoteatr)
        {
            return _kino.InsertKinoteatr(kinoteatr);
        }

        [HttpPut]
        public KinoteatrTDO UpdateKinoteatr(int id, KinoteatrTDO kinoteatr)
        {
            return _kino.UpdateKinoteatr(id, kinoteatr);
        }

        [HttpPatch]
        public int UpdatePatchKinoteatr(int id, string name)
        {
            return _kino.UpdatePatchKinoteatr(id, name);
        }

        [HttpDelete]
        public int DeleteKinoteatr(int id)
        {
            return _kino.DeleteKinoteatr(id);
        }
    }
}
