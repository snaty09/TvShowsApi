using TvShowsApi.Models;

namespace TvShowsApi.Services
{
    public class TvShowService
    {
        private readonly List<TvShow> _tvShows;

        public TvShowService()
        {
            // Inicializar la lista con algunos datos
            _tvShows = new List<TvShow>
            {
                new TvShow { Id = 1, Name = "Breaking Bad", Favorite = true },
                new TvShow { Id = 2, Name = "Game of Thrones", Favorite = false },
                new TvShow { Id = 3, Name = "Stranger Things", Favorite = true }
            };
        }

        public List<TvShow> GetAll() => _tvShows;

        public TvShow GetById(int id) => _tvShows.FirstOrDefault(tvShow => tvShow.Id == id);

        public void Add(TvShow tvShow)
        {
            tvShow.Id = _tvShows.Max(t => t.Id) + 1;
            _tvShows.Add(tvShow);
        }

        public void Update(TvShow tvShow)
        {
            var index = _tvShows.FindIndex(t => t.Id == tvShow.Id);
            if (index != -1)
            {
                _tvShows[index] = tvShow;
            }
        }

        public void Delete(int id)
        {
            var tvShow = GetById(id);
            if (tvShow != null)
            {
                _tvShows.Remove(tvShow);
            }
        }
    }
}
