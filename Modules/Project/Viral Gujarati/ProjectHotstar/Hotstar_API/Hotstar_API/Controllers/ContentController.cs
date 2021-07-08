using Hotstar_API.Models;
using Hotstar_API.Models.Authentication;
using Hotstar_API.Repository.IGenericRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Hotstar.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotstar_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        IContent _content;
        private IVFreeMovie _VFreeMovie;
        private IVMovie _VMovie;
        private ICategory _Category;

        public UserManager<ApplicationUser> userManager;
        private readonly ISubscriptionDetail _subscriptionDetail;
        private IUserAccount _userAccount;

        public ContentController(IUserAccount userAccount,ISubscriptionDetail subscriptionDetail,UserManager<ApplicationUser> userManager, IContent content,IVFreeMovie vFreeMovie,IVMovie vMovie,ICategory category)

        {

            this._content = content;
            _VFreeMovie = vFreeMovie;
            _VMovie = vMovie;
            _Category = category;
            this.userManager = userManager;
            _subscriptionDetail = subscriptionDetail;
            _userAccount = userAccount;

        }

        [HttpGet]
        public IEnumerable<Content> GetAllContent()
        {
            return _content.GetAll();
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Content> GetContent(int id)
        {
            
            var content = _content.GetById(id);
            if (content == null)
            {
                return NotFound();
            }
            //if plan id is not free then login first to view data 
            // in plan id table if there is 2 or 3 id then user must login 
            if (content.PlanId != 1)
            {
                var user = userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                if (user != null)
                {

                    var appUser = _userAccount.Find(u => u.ApplicationUserId == user.Id).FirstOrDefault();
                    if (appUser != null)
                    {
                        var sub  = _subscriptionDetail.Find(s => s.CustomerId == appUser.CustomerId).FirstOrDefault();
                        if (sub == null)
                        {
                            return Ok(new Response()
                            {
                                Status = "fail",
                                Message = "Please Subscribe or Login to Continue"
                            });
                        }
                        var validThrugh = sub.ValidThrough;
                        int valid = DateTime.Compare(validThrugh.Value, DateTime.Now);

                        //validity check for subscription if subscribed or not 
                        
                        var SubDetail = _subscriptionDetail.Any(s => s.CustomerId == appUser.CustomerId && valid >= 0 );
                        if (SubDetail)
                        {
                            return content;
                        }
                        return Ok(new Response()
                        {
                            Status = "fail",
                            Message = "Please Subscribe or Login to Continue"
                        });
                    }
                }
                return Ok(new Response()
                {
                    Status = "fail",
                    Message = "Login First to Access Vip and Premium Content !"
                });

            }
            return content;
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
            return GetContent(id);
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
            return CreatedAtAction("GetContent", new { id = content.ContentId }, content);
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


