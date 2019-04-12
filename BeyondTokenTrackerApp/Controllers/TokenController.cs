using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TokenTracker.Domain.Entities.Dtos;
using TokenTracker.Domain.Entities.Models;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TokenTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public TokenController(IMapper mapper, ITokenService tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(List<TransactionDto>))]
        public IActionResult Get()
        {
            var transactions = _tokenService.GetTokens().ToList();

            // Map the response
            var mappedResponse = _mapper.Map<List<PointTransaction>, List<TransactionDto>>(transactions);

            return Ok(mappedResponse);
        }

        [HttpGet("usertxn")]
        [ProducesResponseType(200, Type = typeof(List<TransactionDto>))]
        public IActionResult Get([FromQuery] int userId)
        {
            var transactions = _tokenService.GetTokens().Where(x => x.AwardFromId == userId || x.AwardToId == userId).ToList();

            // Map the response
            var mappedResponse = _mapper.Map<List<PointTransaction>, List<TransactionDto>>(transactions);

            return Ok(mappedResponse);
        }

        [HttpGet("stats")]
        [ProducesResponseType(200, Type = typeof(TokenStatsDto))]
        public IActionResult GetTokenStats([FromQuery] int userId, [FromQuery] int roleId)
        {
            var stats = _tokenService.GetTokensStats(userId);

            stats.AmtAllotedPeriod = _tokenService.GetAllotedAmount(roleId);

            stats.AmtAvailToGivePeriod = stats.AmtAllotedPeriod + stats.AmtGivenPeriod;

            return Ok(stats);
        }

        [HttpPost("insert")]
        [ProducesResponseType(200, Type = typeof(PointTransaction))]
        public IActionResult InsertTransaction([FromBody] PointTransaction transaction)
        {

            var result = _tokenService.CreateToken(transaction);
            _tokenService.SaveChanges();

            return Ok(result);
        }
    }
}