using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Hotstar.Repo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Hotstar.Controllers
{
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

       private readonly IUserRepo _userRepo;



        public UserController(IUserRepo context)
        {
            this._userRepo = context;
        }



        [HttpGet]
        public IActionResult GetUsers()
        {
            var users =  _userRepo.GetAll();

            return Ok(users);
        }



        //[HttpGet("{id}")]
        //public ActionResult<IUserRepo> GetUsers(int id)
        //{
        //    var userAccount = _userRepo.GetById(id);



        //    if (GetUsers == null)
        //    {
        //        return NotFound();
        //    }



        //    return _userRepo;
        //}



        //[HttpPut("{id}")]
        //public ActionResult<Cinema> PutCinema(int id, Cinema cinema)
        //{

        //    try
        //    {
        //        _userRepo.Update(cinema);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //    return GetCinema(id);

        //}



        //[HttpPost]
        //public ActionResult<> PostCinema(Cinema cinema)
        //{

        //    try
        //    {
        //        .Create(cinema);
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (_userRepo.Any(e => e.CustomerId == cinema.CinemaId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }



        //    return CreatedAtAction("GetId", new { id = cinema.CustomerId }, cinema);
        //}



        //[HttpDelete("{id}")]
        //public IActionResult DeleteCinema(int id)
        //{
        //    var cinema = _userRepo.GetById(id);
        //    if (cinema == null)
        //    {
        //        return NotFound();
        //    }



        //    _userRepo.Delete(cinema);



        //    return NoContent();
        //}




    }
}

