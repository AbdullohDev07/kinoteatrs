using System.Text.Json.Nodes;
using WebApplication1.MyPattern;
using WebApplication1.Roots;
using WebApplication1.RootsTDO;
using WebApplication1.Services.IService;

namespace WebApplication1.Services.Service
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _repository;

        public CinemaService(ICinemaRepository repository)
        {
            _repository = repository;
        }

        public int DeleteCinema(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id 0 bo'lmaydi");
            }
            return _repository.DeleteCinema(id);
        }

        public List<CinemaTDO> GetCinemas()
        {
            var cinemas = _repository.GetCinemas();
            var cinemasDTOS = cinemas.Select(x => new CinemaTDO()
            {
                name = x.name,
                price = x.price,
            });
            return cinemasDTOS.ToList();
        }

        public List<CinemaTDO> GetIdCinema(int id)
        {
            return _repository.GetIdCinema(id);
        }

        public CinemaTDO InsertCinema(CinemaTDO cinemaTDO)
        {
            var cinema = new Cinema()
            {
                name = cinemaTDO.name,
                price = cinemaTDO.price,
            };

            cinema = _repository.InsertCinema(cinema);

            return new CinemaTDO()
            {
                name = cinema.name,
                price = cinema.price,
            };
        }

        public CinemaTDO UpdateCinema(int id, CinemaTDO cinemaTDO)
        {
            var cinema = new Cinema()
            {
                cinama_id = id,
                name = cinemaTDO.name,
                price = cinemaTDO.price
            };

            cinema = _repository.UpdateCinema(cinema);

            return new CinemaTDO()
            {
                name = cinema.name,
                price = cinema.price,
            };
        }

        public int UpdatePatchCinema(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
