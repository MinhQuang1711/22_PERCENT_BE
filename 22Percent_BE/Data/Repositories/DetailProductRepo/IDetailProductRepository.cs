﻿using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.DetailProductRepo
{
    public interface IDetailProductRepository
    {
        public Task<List<DetailProduct>> GetByProductId(string productId);
    }
}