using _22Percent_BE.Data.DTOs.DetailProducts;
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
                product.Id = Guid.NewGuid().ToString();
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

                    detailProduct.ProductId = product.Id;
                    detailProduct.IngredientID = ingredient.Result.Id;
                    detailProduct.IngredientName = ingredient.Result.Name;
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
                dto.Id = product.Id;
                productDtos.Add(dto); 
            }
            
            return productDtos;
        }

        public async Task<string?> delete(BaseModel delete)
        {
            var result = await _context.Products.SingleOrDefaultAsync(e => e.Id == delete.Id); 
            if(result == null)
            {
                return "Sản phẩm không tồn tại";
            }
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();  
            return null;
        }

        public async Task<string?> update(UpdateProductDto update)
        {
            var product = await GetById(update.Id);
            if (product == null)
            {
                return "Sản phẩm không tồn tại"; 
            }
            if (update.ProductName != null) 
            {
                product.Name = update.ProductName;
            }
            if (update.Price.HasValue) 
            {
                product.Price = update.Price.Value;
                product.Profit = (product.Price - product.Cost);
            }
            if (update.DeatailProduct != null)
            {

                var newDetailProducts = new List<DetailProduct>();
                product.Cost = 0;
                // Vòng lặp kiểm tra tồn tại của ingredient, cập nhật dữ liệu
                foreach (var item in update.DeatailProduct)
                {

                    var ingredient = await getIngredient(item.IngredientId);

                    // Nguyên liệu không tồn tại, thông báo lỗi
                    if (ingredient == null)
                    {
                        return Message.IngredientNotExist; 
                    }

                    var detailProduct = new DetailProduct();

                    // Cập nhật dữ liệu của detaiProduct
                    detailProduct.ProductId = product.Id; 
                    detailProduct.IngredientID = ingredient.Id;
                    detailProduct.IngredientName= ingredient.Name;
                    detailProduct.Cost = caculatorCost(item.Weight, ingredient.Cost);

                    product.Cost += detailProduct.Cost;
                    newDetailProducts.Add(detailProduct);
                   
                }
         
                product.Profit=product.Price-product.Cost;  
                product.DetailProducts = newDetailProducts;
                
            }

            _context.Products.Update(product); 
            await _context.SaveChangesAsync();
            return null;
        }

        private async Task<Ingredient?> getIngredient(string id)
        {
            return await _context.Ingredients.SingleOrDefaultAsync(e => e.Id == id);

        }

        public async Task<Product?> GetById(string id)
        {
            
            return await _context.Products
                .Include(e=> e.DetailProducts)
                .SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}
