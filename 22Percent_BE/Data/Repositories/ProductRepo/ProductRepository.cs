//using _22Percent_BE.Data.DTOs.DetailProducts;
//using _22Percent_BE.Data.DTOs.Products;
//using _22Percent_BE.Data.Entities;
//using AutoMapper;
//using Microsoft.EntityFrameworkCore;

//namespace _22Percent_BE.Data.Repositories.ProductRepo
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly _22Context _context;
//        private readonly IMapper _mapper;

//        public ProductRepository(_22Context context,IMapper mapper) 
//        {
//            _context=context;
//            _mapper=mapper;
//        }
//        public async Task<bool> create(CreateProductDto create)
//        {
//            try
//            {
//                var product = _mapper.Map<Product>(create); 
//                product.id=Guid.NewGuid().ToString();
//                var detailProductList = new List<DetailProduct>();

//                foreach (var item in create.DetailProducts)
//                {
//                    var detailProduct= _mapper.Map<DetailProduct>(item);
//                    var ingredient = getIngredient(detailProduct.IngredientID);

//                    // Không thể tạo sản phẩm khi không tồn tại nguyên liệu
//                    if (ingredient.Result==null)
//                    {
//                        return false;
//                    }

//                    detailProduct.Product = product;
//                    detailProduct.ProductId = product.id;
//                    detailProduct.Ingredient = ingredient.Result;
//                    detailProduct.ProductId = ingredient.Result.id;
//                    detailProduct.Cost = caculatorCost(item.Weight, ingredient.Result.Cost);
//                    product.Cost += detailProduct.Cost; 

//                    detailProductList.Add(detailProduct);
                    
//                }
//                product.DetailProducts = detailProductList;
//                _context.DetailProducts.AddRange(detailProductList);
//                _context.Products.Add(product);
//                await _context.SaveChangesAsync();
//                return true;

//            }
//            catch (Exception ex) 
//            {
//                return false;
//            }
//        }

//        private async Task<Ingredient?> getIngredient(string id) 
//        {
//            return await _context.Ingredients.SingleOrDefaultAsync(e=> e.id==id);

//        }

//        private double caculatorCost (double weight, double cost)
//        {
           
//            return weight*cost;
           
//        }

        
//    }
//}
