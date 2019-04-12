using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenTracker.Domain.Entities.Dtos;

namespace TokenTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamelyController : ControllerBase
    {
        private readonly IUserService _userService;

        public NamelyController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("namely")]
        public IActionResult NamelyUpdate([FromBody] List<NamelyUpdateSvm> namelyUsers)
        {

            var result = _userService.NamelyUpdate(namelyUsers);
            _userService.SaveChanges();

            return Ok(result);
        }
    }
}