using _22Percent_BE.Data.DTOs.Inventories;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.Inventories
{
    public class InventoryServices : IInventoryServices
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public InventoryServices(IRepositoryManagement repositoryManagement)
        {
            _repositoryManagement = repositoryManagement;
        }

        public async Task<GetInventoryDto?> GetByName(string storeName)
        {
            var entity = await _repositoryManagement.InventoryRepository.GetByName(storeName);
            return entity?.ToGetInventoryDto();
        }
    }
}
