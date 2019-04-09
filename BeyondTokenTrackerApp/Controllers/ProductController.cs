using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities.Dtos;
using Domain.Entities.Models;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTokenTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _tokenService;

        public ProductController(IMapper mapper, IProductService tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult Get()
        {
            var products = _tokenService.GetProducts().ToList();

            // Map the response
            var mappedResponse = _mapper.Map<List<Product>, List<ProductDto>>(products);

            return Ok(mappedResponse);
        }

        [HttpGet("redeemable")]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public IActionResult GetRedeemable()
        {
            var products = _tokenService.GetRedeemableProducts().ToList();

            // Map the response
            var mappedResponse = _mapper.Map<List<Product>, List<ProductDto>>(products);

            return Ok(mappedResponse);
        }

        [HttpGet("id")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult Get([FromQuery] int productId)
        {
            var product = _tokenService.GetProducts().FirstOrDefault(x => x.ProductId == productId);

            // Map the response
            var mappedResponse = _mapper.Map<Product, ProductDto>(product);

            return Ok(mappedResponse);
        }
        
    }
}
