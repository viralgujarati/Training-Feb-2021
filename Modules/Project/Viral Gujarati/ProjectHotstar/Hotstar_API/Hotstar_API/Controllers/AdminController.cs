using Hotstar_API.Models;
using Hotstar_API.Models.Authentication;
using Hotstar_API.Repository.IGenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotstar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IContent _content;


        public AdminController(IContent content)

        {
            this._content = content;

        }


            [HttpPut("{​​​id}​​​")]
        public ActionResult<Content> PutContent(int id, Content content)
        {
            try
            {
                _content.Update(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult<Content> PostContent(Content content)
        {
            try
            {
                _content.Create(content);
            }
            catch (DbUpdateException)
            {
                if (_content.Any(e => e.ContentId == content.ContentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("PostContent", new { id = content.ContentId }, content);
        }

        [HttpDelete("{​​​id}​​​")]
        public IActionResult DeleteContent(int id)
        {
            var content = _content.GetById(id);
            if (content == null)
            {
                return NotFound();
            }
            _content.Delete(content);
            return NoContent();
        }

    }
}
