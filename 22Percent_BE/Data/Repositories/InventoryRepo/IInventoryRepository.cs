using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.InventoryRepo
{
    public interface IInventoryRepository
    {
        public Task<Inventory?> GetByName(string nameStore);
    }
}
