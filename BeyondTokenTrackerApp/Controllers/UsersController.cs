using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTokenTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<User> Users()
        {
            var listUsers = _userService.GetUsers().ToList();

            return listUsers;
        }

        [HttpGet("login")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            var authenticatedUser = _userService.GetUsers().FirstOrDefault(x => x.Email == email && x.Password == password);

            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            return Ok(authenticatedUser);
        }
    }
}