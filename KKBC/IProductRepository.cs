using KKBC.Controllers;
using KKBC.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAllProducts();

        public IEnumerable<ScentName> GetAllScents();

        public ScentName GetScent(int id);

        public Category GetCategory(int id);

        public Products GetProduct(int id);

        public void UpdateProduct(Products products);

        public void UpdateScent(ScentName scent);

        public void UpdateCategory(Category cat);

        public void InsertProduct(Products productToInsert);

        public void InsertScent(ScentName scent);

        public void InsertCategory(Category category);

        public IEnumerable<Category> GetCategories();
        public IEnumerable<Scents> GetScents();

        public IEnumerable<ScentName> GetName();

        public void DeleteProduct(Products product);

        public void DeleteCategory(Category category);

        public void DeleteScent(ScentName scent);

        public Products AssignCategory();

        public Products AssignScent();


    }
}
