﻿using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.DetailProductRepo
{
    public interface IDetailProductRepository
    {
        public Task<string?> CreateList(List<DetailProduct> list);

        public Task DeleteListAsync(string productId);

        public string? DeleteList(string productId);
    }
}
