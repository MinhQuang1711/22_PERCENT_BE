﻿using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly _22Context _context;
        private readonly IMapper _mapper;

        public ProductRepository(_22Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string?> create(CreateProductDto create)
        {
            try
            {
                var product = _mapper.Map<Product>(create);
                product.id = Guid.NewGuid().ToString();
                var detailProductList = new List<DetailProduct>();

                foreach (var item in create.DetailProducts)
                {
                    var detailProduct = _mapper.Map<DetailProduct>(item);
                    var ingredient = getIngredient(detailProduct.IngredientID);

                    // Không thể tạo sản phẩm khi không tồn tại nguyên liệu
                    if (ingredient.Result == null)
                    {
                        return "Một trong số nguyên liệu bạn chọn không tồn tại";
                    }

                    
                    detailProduct.ProductId = product.id;
                    detailProduct.IngredientID = ingredient.Result.id;
                    detailProduct.Cost = caculatorCost(item.Weight, ingredient.Result.Cost);
                    product.Cost += detailProduct.Cost;

                    detailProductList.Add(detailProduct);

                }
                product.Profit = (product.Price - product.Cost);
                product.DetailProducts = detailProductList;
                _context.DetailProducts.AddRange(detailProductList);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<Ingredient?> getIngredient(string id)
        {
            return await _context.Ingredients.SingleOrDefaultAsync(e => e.id == id);

        }

        private double caculatorCost(double weight, double cost)
        {

            return weight * cost;

        }

        public async Task<List<GetproductDto>> getAll()
        {
           var products= await _context.Products.Include(e=>e.DetailProducts).ToListAsync();
            
           var productDtos= new List<GetproductDto>();
            foreach (var product in products)
            {
                
                var dto= product.ToGetProductDto();
                dto.id = product.id;
                productDtos.Add(dto); 
            }
            
            return productDtos;
        }

        public async Task<string?> delete(BaseModel delete)
        {
            var result = await _context.Products.SingleOrDefaultAsync(e => e.id == delete.id); 
            if(result == null)
            {
                return "Sản phẩm không tồn tại";
            }
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();  
            return null;
        }
    }
}
