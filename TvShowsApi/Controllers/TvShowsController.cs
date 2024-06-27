using Microsoft.AspNetCore.Mvc;
using TvShowsApi.Models;
using TvShowsApi.Services;

namespace TvShowsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TvShowsController : ControllerBase
    {
        private readonly TvShowService _service;

        public TvShowsController(TvShowService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TvShow>> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<TvShow> GetById(int id)
        {
            var tvShow = _service.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }
            return tvShow;
        }

        [HttpPost]
        public IActionResult Create(TvShow tvShow)
        {
            _service.Add(tvShow);
            return CreatedAtAction(nameof(GetById), new { id = tvShow.Id }, tvShow);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TvShow tvShow)
        {
            if (id != tvShow.Id)
            {
                return BadRequest();
            }

            var existingTvShow = _service.GetById(id);
            if (existingTvShow == null)
            {
                return NotFound();
            }

            _service.Update(tvShow);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tvShow = _service.GetById(id);
            if (tvShow == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
