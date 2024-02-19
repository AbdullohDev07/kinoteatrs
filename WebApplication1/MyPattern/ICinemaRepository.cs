using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public interface ICinemaRepository
    {
        public List<Cinema> GetCinemas();
        public List<Cinema> GetIdCinema(int id);
        public CinemaTDO InsertCinema(CinemaTDO cinema);
        public CinemaTDO UpdateCinema(int id, CinemaTDO cinema);
        public int UpdatePatchCinema(int id, string name);
        public int DeleteCinema(int id);
    }
}
