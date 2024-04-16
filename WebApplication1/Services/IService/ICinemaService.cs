using WebApplication1.MyPattern;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.Services.IService
{
    public interface ICinemaService
    {
        public List<CinemaTDO> GetCinemas();
        public List<CinemaTDO> GetIdCinema(int id);
        public CinemaTDO InsertCinema(CinemaTDO cinema);
        public CinemaTDO UpdateCinema(int id, CinemaTDO cinema);
        public int UpdatePatchCinema(int id, string name);
        public int DeleteCinema(int id);
    }
}
