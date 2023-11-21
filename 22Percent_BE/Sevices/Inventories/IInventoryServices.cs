using _22Percent_BE.Data.DTOs.Inventories;

namespace _22Percent_BE.Sevices.Inventories
{
    public interface IInventoryServices
    {
        public Task<GetInventoryDto?> GetByName(string storeName);
    }
}
