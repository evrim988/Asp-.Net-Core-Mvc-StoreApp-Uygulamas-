﻿using BLL.Abstract;
using DataAccess.Database;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly StoreAppContext _context;
        public ProductRepository(StoreAppContext context) : base(context)
        {
            context = _context;
        }

        public IQueryable<Product> GetList(bool trackChanges) => FindAll(trackChanges);
       
    }
}