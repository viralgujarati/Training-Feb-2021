using Hotstar_API.Models;
using Hotstar_API.Models.Authentication;
using Hotstar_API.Repository.IGenericRepository;
using Hotstar_API.Service.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_Hotstar.Authentication;
using Project_Hotstar.Models.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Hotstar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserAccount _UserAccount;
        private readonly IMailService _mailService;

        public AuthenticateController(IMailService mailService ,  UserManager<ApplicationUser> userManager, IUserAccount userAccount, RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _UserAccount = userAccount;
            _mailService = mailService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                //step4 
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (!result.Succeeded)
                {
                    var userFromDb = await userManager.FindByNameAsync(user.UserName);

                    var emailtoken = await userManager.GenerateEmailConfirmationTokenAsync(userFromDb);

                    var uriBuilder = new UriBuilder(_configuration["ReturnPaths:ConfirmEmail"]);
                    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    query["token"] = emailtoken;
                    query["userid"] = userFromDb.Id;
                    uriBuilder.Query = query.ToString();
                    var urlString = uriBuilder.ToString();

                    var emailstruct = new MailRequest();
                    emailstruct.Subject = "Confirm your email address";
                    emailstruct.Body = $"<a href=\"{urlString}\" style=\"text-decoration: none;\">Verify Email</a>";
                    emailstruct.ToEmail = userFromDb.Email;
                    await _mailService.SendEmailAsync(emailstruct);


                    return Ok(new
                    {
                        Status = "Fail",
                        Message = "User Email is Not Verified! Please Verify Your Email First"
                    });
                }


                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                //authentication
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var appUser = _UserAccount.Find(u => u.ApplicationUserId == user.Id).FirstOrDefault();


                var response = new Response { Status = "Success", Message = "Login successfully!" };

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    response.Status,
                    response.Message,
                    userId = appUser.CustomerId
                });
            }
            return Unauthorized();
        }

       


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            //already exist
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Already Exists !" });

            // for new user  
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation Failed! Please Check User Details." });


            UserAccount AppUser = new UserAccount()
            {
                Name = model.Name,
                Email = model.Email,
                ApplicationUserId = user.Id,
                PhoneNumber = model.Phone,
                Address = model.Address
            };

            _UserAccount.Create(AppUser);

            // For Email Verification  step 1 
            var userFromDb = await userManager.FindByNameAsync(user.UserName);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(userFromDb);
            var uriBuilder = new UriBuilder(_configuration["ReturnPaths:ConfirmEmail"]);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["token"] = token;
            query["userid"] = userFromDb.Id;
            uriBuilder.Query = query.ToString();
            var urlString = uriBuilder.ToString();
            
            var emailstruct = new MailRequest();
            emailstruct.Subject = "Confirm your email address";
            emailstruct.Body = $" <h3>This Email is to verify for your registration process. Please verify below link to verify your account. </h3><a href=\"{urlString}\" style=\"text-decoration: none;\">Verify Email</a>";
            emailstruct.ToEmail = userFromDb.Email;
            await _mailService.SendEmailAsync(emailstruct);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


        //step 2  method for email verify step 3-startup

        [HttpPost]
        [Route("verifyEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            var result = await userManager.ConfirmEmailAsync(user, model.Token);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}

