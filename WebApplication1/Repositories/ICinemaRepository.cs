using WebApplication1.Roots;
using WebApplication1.RootsTDO;

namespace WebApplication1.MyPattern
{
    public interface ICinemaRepository
    {
        public List<Cinema> GetCinemas();
        public List<CinemaTDO> GetIdCinema(int id);
        public Cinema InsertCinema(Cinema cinema);
        public Cinema UpdateCinema(Cinema cinema);
        public int UpdatePatchCinema(int id, string name);
        public int DeleteCinema(int id);
    }
}
