using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TokenTracker.Domain.Entities.Dtos;
using TokenTracker.Domain.Entities.Models;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TokenTrackerApp.Controllers
{
    public class TokenTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITokenTypeService _tokenTypeService;

        public TokenTypeController(IMapper mapper, ITokenTypeService tokenTypeService)
        {
            _mapper = mapper;
            _tokenTypeService = tokenTypeService;
        }

        [HttpGet("id")]
        [ProducesResponseType(200, Type = typeof(TransactionTypeDto))]
        public IActionResult GetId([FromQuery] int id)
        {
            var type = _tokenTypeService.GetTokenTypes().FirstOrDefault(x => x.PointTransactionTypeId == id);

            // Map the response
            var mappedResponse = _mapper.Map<PointTransactionType, TransactionTypeDto>(type);

            return Ok(mappedResponse);
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(List<TransactionTypeDto>))]
        public IActionResult Get()
        {
            var transactions = _tokenTypeService.GetTokenTypes().ToList();

            // Map the response
            var mappedResponse = _mapper.Map<List<PointTransactionType>, List<TransactionTypeDto>>(transactions);

            return Ok(mappedResponse);
        }

        [HttpGet("role")]
        [ProducesResponseType(200, Type = typeof(List<TransactionTypeDto>))]
        public IActionResult Get([FromQuery] int roleId)
        {
            var types = _tokenTypeService.GetTokenTypes().Where(x => x.RoleId == roleId).ToList();

            // Map the response
            var mappedResponse = _mapper.Map<List<PointTransactionType>, List<TransactionTypeDto>>(types);

            return Ok(mappedResponse);
        }

        
    }
}
