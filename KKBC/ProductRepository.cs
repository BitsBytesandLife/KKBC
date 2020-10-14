using Dapper;
using KKBC.Controllers;
using KKBC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Products AssignCategory()
        {
            var categoryList = GetCategories();
            var scentList = GetScents();
            var scentName = GetName();
            var product = new Products();
            product.Categories = categoryList;
            product.Scents = scentList;
            product.ScentName = scentName; 
         
            return product;
        }

        public Products AssignScent()
        {
            var scentList = GetScents();
            var product = new Products();
            product.Scents = scentList;

            return product; 
            //throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            _conn.Execute("DELETE FROM category WHERE CatID = @id;",
                                       new { id = category.CatID });
        }

        public void DeleteProduct(Products product)
        {
            _conn.Execute("DELETE FROM products WHERE ProdID = @id;",
                                        new { id = product.ProdID });
        }

        public void DeleteScent(ScentName scent)
        {
            _conn.Execute("DELETE FROM scent_details WHERE ScentID = @id;",
                                       new { id = scent.ScentID });
            //throw new NotImplementedException();
        }

        public IEnumerable<Products> GetAllProducts()
        {  
            return _conn.Query<Products>("SELECT * FROM products; ");
            //
            //SELECT p.ProdID, p.Name, c.Name,p.StockLevel ,p.Price FROM products p INNER JOIN  category c WHERE c.CatID = p.CatID;
        }

        public IEnumerable<ScentName> GetAllScents()
        {
            return _conn.Query<ScentName>("SELECT * from scent_details;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM category");

        }

        public Category GetCategory(int id)
        {
            return _conn.QuerySingle<Category>("SELECT * FROM category WHERE CatID = @id",
               new { id = id });
        }

        public IEnumerable<ScentName> GetName()
        {
            return _conn.Query<ScentName>("SELECT Name FROM scent_details;");
        }

        public Products GetProduct(int id)
        { 
                return _conn.QuerySingle<Products>("SELECT * FROM products WHERE prodID = @id",
                    new { id = id });
        }

        public ScentName GetScent(int id)
        {
            return _conn.QuerySingle<ScentName>("SELECT * FROM scent_details WHERE ScentID = @id",
                new { id = id });

        }

        public IEnumerable<Scents> GetScents()
        {
            return _conn.Query<Scents>("SELECT * FROM scents;");
        }

        public void InsertCategory(Category category)
        {
            _conn.Execute("INSERT INTO category (Name) VALUES (@name);",
                          new { name = category.Name});
        }

        public void InsertProduct(Products productToInsert)
        {
            _conn.Execute("INSERT INTO products (Name,CatID,ScentID,StockLevel,Price) VALUES (@name,@catID,@scentID,@stockLevel,@price);",
               new { name = productToInsert.Name, catID = productToInsert.CatID, scentID = productToInsert.ScentID, 
                   stockLevel = productToInsert.StockLevel, price = productToInsert.Price, });

        }

        public void InsertScent(ScentName scent)
        {
            _conn.Execute("INSERT INTO scent_details (Name, Description) VALUES (@name,@desc); ",
                            new { name = scent.Name,desc =scent.Description });
        }

        public void UpdateCategory(Category cat)
        {
            _conn.Execute("UPDATE category SET Name = @name WHERE CatID = @id; ",
                           new { name = cat.Name, id = cat.CatID });
        }

        public void UpdateProduct(Products products)
        {
            _conn.Execute("UPDATE products SET Name = @name, StockLevel = @stockLevel, Price = @price WHERE ProdID = @id; ",
                          new { name = products.Name,stockLevel = products.StockLevel, price = products.Price, id = products.ProdID });
        }

        public void UpdateScent(ScentName scent)
        {
            _conn.Execute("UPDATE scent_details SET Name = @name, Description = @desc WHERE ScentID = @id; ",
                new { name = scent.Name, desc = scent.Description, id = scent.ScentID }); 
        }
    }
}
