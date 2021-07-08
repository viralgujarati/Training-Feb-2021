using Hotstar_API.Models;
using Hotstar_API.Models.Authentication;
using Hotstar_API.Repository.IGenericRepository;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]/{userid}")]
    [ApiController]
    public class VIPUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        IContent _content;
        private IUserAccount _UserAccount;
        private IPlan _plan;
        private ISubscriptionDetail _subscriptionDetail;

        public VIPUserController(IContent content, ISubscriptionDetail subscriptionDetail, UserManager<ApplicationUser> userManager, IUserAccount userAccount, IPlan plan)
        {
            _userManager = userManager;
            this._content = content;
            _UserAccount = userAccount;
            _plan = plan;
            _subscriptionDetail = subscriptionDetail;

        }

        [HttpGet]
        public IActionResult GetAllPremiumContent(int userid)
        {
            var user = _userManager.Users.First(x => x.UserName == User.Identity.Name);
            var customer = _UserAccount.Find(x => x.ApplicationUserId == user.Id).FirstOrDefault();

            if (!_UserAccount.ValidateUser(user.Id, userid))
            {
                return Unauthorized();
            }
            if (!_subscriptionDetail.Any(s => s.CustomerId == customer.CustomerId))

            {
                return Unauthorized();

            }

            var plan = _plan.Find(p => p.PlanCategory == "Premium").FirstOrDefault().PlanId;
            var content = _content.Find(c => c.PlanId == plan).ToList();

            return Ok(content);
        }

        [HttpGet]
        [Route("{contentid}")]

        public IActionResult GetPremiumContentById(int userid, int contentid)
        {
            var user = _userManager.Users.First(x => x.UserName == User.Identity.Name);
            var customer = _UserAccount.Find(x => x.ApplicationUserId == user.Id).FirstOrDefault();
            if (!_UserAccount.ValidateUser(user.Id, userid))
            {
                return Unauthorized();
            }

            if (!_subscriptionDetail.Any(s => s.CustomerId == customer.CustomerId))

            {
                return Unauthorized();

            }

            var plan = _plan.Find(p => p.PlanCategory == "Premium").FirstOrDefault().PlanId;

            var content = _content.Find(c => c.PlanId == plan && c.ContentId == contentid).FirstOrDefault();

            return Ok(content);
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


//
//context.Students
//                      .FromSql($"GetStudents {name}")
//                      .ToList();


