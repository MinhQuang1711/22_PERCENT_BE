﻿using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public Product(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var dtos = await _serviceManagement.ProductService.GetAll();
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("search-by-filter")]
        public async Task<IActionResult> SeachByName(SearchProductDto search) 
        {
            try
            {
                if (search.FromPrice !=null && search.ToPrice !=null)
                {
                    if(search.FromPrice == search.ToPrice)
                    return BadRequest(Message.RangPriceCantTheSame);
                }
                var dtos= await _serviceManagement.ProductService.SearchByFilter(search);
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("search_by-id")]
        public async Task<IActionResult> SearchById(BaseModel model)
        {
            try
            {
                var dto = await _serviceManagement.ProductService.GetProductById(model.Id);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var productId=Guid.NewGuid().ToString();
            var productMessage= await _serviceManagement.ProductService.Create(dto,productId);
            //var detailProductMessge = await _serviceManagement.DetailProductService.CreateList(dto.DetailProducts,productId);
            if (productMessage != null)
            {
                return BadRequest(productMessage);
            }
            //if (detailProductMessge != null)
            //{
            //    _serviceManagement.DetailProductService.Delete(productId);
            //    return BadRequest(detailProductMessge); 
            //}
            return Ok(dto);
        }
    }
}
