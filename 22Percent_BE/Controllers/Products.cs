﻿using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories.ProductRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public Products(IProductRepository productRepository) 
        {
            _productRepository= productRepository;
        }

        [HttpPost("Search-By-Id")]
        public IActionResult searchById(BaseModel model)
        {
            var result = _productRepository.GetById(model.Id);
          
            if (result.Result != null)
            {
                var dto= result.Result.ToGetProductDto();
                dto.Id = model.Id;
                return Ok(dto);
            }
            return Ok(result);
        }

       
    }
}
