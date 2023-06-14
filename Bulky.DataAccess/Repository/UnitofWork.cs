﻿using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitofWork : IUnitOfwork
    {
        private readonly ApplicationdbContext _db;
        public ICategoryRepository Category
        {
            get; private set;
        }
        public IProductRepository Product 
        {
            get; private set;
        }
        public UnitofWork(ApplicationdbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}