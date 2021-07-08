using Hotstar_API.Repository.IGenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotstar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IContent _content;
        private readonly IVFreeMovie _VFreeMovie;
        private readonly IVMovie _VMovie;
        private readonly ICategory _Category;
        private readonly IVSport _VSport;

        public HomeController(
            IContent content,
            IVFreeMovie vFreeMovie,
            IVMovie vMovie,
            IVSport vSport,
            ICategory category)

        {
            _content = content;
            _VFreeMovie = vFreeMovie;
            _VMovie = vMovie;
            _Category = category;
            _VSport = vSport;
        }

        [HttpGet]
        [Route("AllMovies")]
        public IActionResult GetAllMovies()
        {
            var movies = _VMovie.GetAll();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("AllSports")]
        public IActionResult GetAllSports()
        {
            var sports = _VSport.GetAll();
            return Ok(sports);
        }

        [HttpGet]
        [Route("AllShows")]
        public IActionResult GetAllShows()
        {
            var shows = _content.Find(s => s.CategoryId == 1);
            return Ok(shows);
        }


        [HttpGet]
        [Route("AllPremium")]
        public IActionResult GetAllPremium()
        {
            var premium = _content.Find(c=>c.PlanId != 1);
            return Ok(premium);
        }

        [HttpGet]
        [Route("GetShowByCategory/{categoryId}/{subCategoryId}")]
        public IActionResult GetShowByCategory(int categoryId, int subCategoryId)
        {
            var allContent = _content.Find(c => c.CategoryId == categoryId && c.SubCategoryId == subCategoryId).AsEnumerable();
            return Ok(allContent);
        }

        [HttpGet]
        [Route("GetAllMoviesByLanguage/{language}")]
        public IActionResult GetMovieByLanguage(string language)
        {
            var allContent = _content.Find(c => c.CategoryId == 2 && c.ContentLanguage == language).AsEnumerable();
            return Ok(allContent);
        }

        [HttpGet]
        [Route("GetAllSports/{SubCatID}")]
        public IActionResult GetSportBySubCate(int SubCatID)
        {
            var allContent = _content.Find(c => c.CategoryId == 3 && c.SubCategoryId == SubCatID).AsEnumerable();
            return Ok(allContent);
        }
    }
}
