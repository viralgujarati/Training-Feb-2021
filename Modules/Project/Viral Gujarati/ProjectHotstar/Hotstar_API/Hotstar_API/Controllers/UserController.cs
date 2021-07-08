using Hotstar_API.Models;
using Hotstar_API.Models.Authentication;
using Hotstar_API.Repository.IGenericRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project_Hotstar.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotstar_API.Controllers
{
    
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        
        private readonly IUserAccount _UserAccount;
        private readonly ISubscriptionDetail _subscriptionDetail;
        private readonly ISubscriptionPriceList _subscriptionPriceList;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IUserAccount userAccount,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ISubscriptionDetail subscriptionDetail,
            ISubscriptionPriceList subscriptionPriceList)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _UserAccount = userAccount;
            _subscriptionDetail = subscriptionDetail;
            _subscriptionPriceList = subscriptionPriceList;
        }

        [Authorize]
        [HttpGet]
        [Route("Subscribe/{planId}")]
        //check if user is valid or not 
        public ActionResult GetSubscribe(int userId, int planId)
        {
            var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
            var customer = _UserAccount.Find(x => x.ApplicationUserId == user.Id).FirstOrDefault();

            if (!_UserAccount.ValidateUser(user.Id, userId))
            {
                return Unauthorized();
            }
            //from price list it will check 
            var subPrice = _subscriptionPriceList.Find(s => s.PlanId == planId).FirstOrDefault();
            var validity = 0;
            if (subPrice == null)
            {
                return BadRequest();
            }

            if (subPrice.Validity == "Monthly")
            {
                validity = 28;
            }
            else
            {
                validity = 365;
            }
            //check if customer has already subscribe 
            //if customer validity expired  then only it will ask for new subscrption
            if (_subscriptionDetail.Any(s => s.CustomerId == customer.CustomerId))
            {
                var validThrugh = _subscriptionDetail.Find(s => s.CustomerId == customer.CustomerId).First().ValidThrough;
                int valid = DateTime.Compare(validThrugh.Value, DateTime.Now);

                if (valid < 0)
                {
                    var subscribe = new SubscriptionDetail()
                    {
                        CustomerId = customer.CustomerId,
                        PlanId = planId,
                        SubcriptionPriceListId = subPrice.Id,
                        DateOfSubscription = DateTime.Now,
                        ValidThrough = DateTime.Now.AddDays(validity)

                    };
                    _subscriptionDetail.Create(subscribe);

                    return Ok(
                        new
                        {
                            Status = "Success",
                            Message = "Subscription Successfully Done",
                            subscribe.ValidThrough
                        });
                }

                return Ok(new { Status = "Fail", Message = "You have already Subscribed" });
            }


            var subscription = new SubscriptionDetail()
            {
                CustomerId = customer.CustomerId,
                PlanId = planId,
                SubcriptionPriceListId = subPrice.Id,
                DateOfSubscription = DateTime.Now,
                ValidThrough = DateTime.Now.AddDays(validity)

            };
            _subscriptionDetail.Create(subscription);

            return Ok(
                new
                {
                    Status = "Success",
                    Message = "Subscription Successfully Done",
                    subscription.ValidThrough
                });
        }
    }
}
