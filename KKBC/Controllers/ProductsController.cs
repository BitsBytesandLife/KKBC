using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKBC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KKBC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository repo;

        public ProductsController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            return View(products);
        }
         
        public IActionResult GetAllScents()
        {
            var scentNames = repo.GetAllScents();

            return View(scentNames);
        }

        public IActionResult ViewScent(int id)
        {
            var scent = repo.GetScent(id);

            return View(scent);
        }


        public IActionResult GetCategories()
        {
            var categories = repo.GetCategories();

            return View(categories);
        }

        public IActionResult GetCategory(int id)
        {
            var category = repo.GetCategory(id);

            return View(category);
        }

        public IActionResult ViewCategory(int id)
        {
            var category = repo.GetCategory(id);

            return View(category);
        }

        public IActionResult ViewProduct(int id)
        {
            var products = repo.GetProduct(id);

            return View(products);
        }

        public IActionResult UpdateProduct(int id)
        {
            Products prod = repo.GetProduct(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }


        public IActionResult UpdateScent(int id)
        {
            ScentName scent = repo.GetScent(id);

            if (scent == null)
            {
                return View("ProductNotFound");
            }

            return View(scent);

        }

        public IActionResult UpdateCategory(int id)
        {
            Category category = repo.GetCategory(id);

            if (category == null)
            {
                return View("ProductNotFound");
            }

            return View(category);
        }


        public IActionResult UpdateProductToDatabase(Products product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProdID });
        }

        public IActionResult UpdateSCentToDatabase(ScentName scent)
        {
            repo.UpdateScent(scent);

            return RedirectToAction("ViewScent", new { id  = scent.ScentID});
        }

        public IActionResult UpdateCategoryToDatabase(Category category)
        {
            repo.UpdateCategory(category);

            return RedirectToAction("ViewCategory", new {id =category.CatID });
        }



        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertScent()
        {
            var scent = new ScentName();
            
            return View(scent);
        }


        public IActionResult InsertCategory()
        {
            var category = new Category();

            return View(category);
        }


        public IActionResult InsertScentToDatabase(ScentName scentToInsert)
        {
            repo.InsertScent(scentToInsert);

            return RedirectToAction("GetAllScents");
        }

        public IActionResult InsertCategoryToDatabase(Category categoryToInsert)
        {
            repo.InsertCategory(categoryToInsert);

            return RedirectToAction("GetCategories");
        }


        public IActionResult InsertProductToDatabase(Products productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Products product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(Category category)
        {
            repo.DeleteCategory(category);

            return RedirectToAction("GetCategories");
        }

      public IActionResult DeleteScent(ScentName scent)
      {
            repo.DeleteScent(scent);

            return RedirectToAction("GetAllScents");
      }


    }
}
