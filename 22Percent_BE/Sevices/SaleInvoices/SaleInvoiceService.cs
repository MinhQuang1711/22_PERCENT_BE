using _22Percent_BE.Data;
using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.DTOs.SaleInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.SaleInvoices
{
    public class SaleInvoiceService : ISaleInvoiceService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public SaleInvoiceService(IRepositoryManagement repositoryManagement)
        {
            _repositoryManagement = repositoryManagement;
        }

        /*
         * Thực hiện trừ kho nguyên liệu tương ứng và thêm mới hóa đơn
        */

        public async Task<string?> Create(CreateSaleInvoiceDto dto, string currentUser)
        {
            
            foreach (var item in dto.DetailSaleInvoiceDtos)
            {
                var product = await _repositoryManagement.ProductRepository.GetById(item.ProductId);
                if (product != null)
                {
                    // Lấy danh sách detailProduct từ đó lấy được ra detailIngredient tương ứng
                    var detailProducts = await _repositoryManagement.DetailProductRepository.GetByProductId(product.Id); 
                    if (detailProducts != null)
                    {
                        foreach (var item1 in detailProducts)
                        {
                            var detailIngredient = item1.Ingredient.DetailIngredient;
                            // cập nhật trọng lượng và cost nếu tồn tại detailIngredient
                            if (detailIngredient != null)
                            {
                                detailIngredient.Weight -= item1.Weight *item.Quantity;
                                detailIngredient.ToalCost -= item.Quantity * item1.Cost;
                            }
                            else
                            {
                                return Message.IngredientNotExist;
                            } 
                        }
                        var saleInvoice= dto.ToSaleInvoicce();
                        saleInvoice.CreateUser = currentUser;
                        await _repositoryManagement.saleInvoiceRepository.Create(saleInvoice);
                        return null;
                    }
                    return Message.ProductNotExist; 

                }
                    return Message.ProductNotExist;  
                
            }
            return null;    
        }

        public async Task<string?> Delete(string id)
        {

            return await _repositoryManagement.saleInvoiceRepository.Delete(id);
        }

        public async Task<List<GetSaleInvoiceDto>> GetAll(string currentUser)
        {
            var saleInvoices= await _repositoryManagement.saleInvoiceRepository.GetAll();
            saleInvoices = saleInvoices.Where(e => e.CreateUser == currentUser).ToList();
            return saleInvoices.Select(e=> e.ToGetSaleInvoiceDto()).ToList();
        }

        public async Task<List<GetSaleInvoiceDto>> GetByFilter(SearchSaleInvoiceDto dto, string currentUser)
        {
            var saleiInvoice= await _repositoryManagement.saleInvoiceRepository.GetByFilter(dto, currentUser);
            return saleiInvoice.Select(e=> e.ToGetSaleInvoiceDto()).ToList();
        }

        public async Task<GetSaleInvoiceDto?> GetById(string id)
        {
            var saleInvoice= await _repositoryManagement.saleInvoiceRepository.GetById(id);
            return saleInvoice?.ToGetSaleInvoiceDto();
        }
    }
}
