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
    public class MovieController : ControllerBase
    {
        IContent _content;
        private IVFreeMovie _VFreeMovie;
        private IVMovie _VMovie;
        private ICategory _Category;

        public MovieController(IContent content, IVFreeMovie vFreeMovie, IVMovie vMovie, ICategory category)

        {
            this._content = content;
            _VFreeMovie = vFreeMovie;
            _VMovie = vMovie;
            _Category = category;
        }

        [HttpGet]
        public ActionResult GetAllMovies()
        {
            var content = _VMovie.GetAll();
            if (content == null)
            {
                return NotFound();
            }
            return Ok(content);
        }


        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetMovieById(int Id)
        {
            var cId = _Category.Find(c => c.CategoryName == "Movies").FirstOrDefault().CategoryId;
            var content = _content.Find(c => c.ContentId == Id && c.CategoryId == cId).FirstOrDefault();
            if (content == null)
            {
                return NotFound();
            }
            return Ok(content);
        }
    }
}
