﻿using Microsoft.AspNetCore.Mvc;
using WebAppViews.Models;

namespace WebAppViews.ViewComponents
{
    public class TopProductsViewComponent : ViewComponent
    {
        public class ProductRepository
        {
            public async Task<List<Product>> GetTopProductsAsync(int count)
            {
                IEnumerable<Product> products = new List<Product>()
            {
                new Product { ProductID =1, Name ="Product 1", Category = "Category 1", Description ="Description 1", Price = 10m},
                new Product { ProductID =2, Name ="Product 2", Category = "Category 1", Description ="Description 2", Price = 20m},
                new Product { ProductID =3, Name ="Product 3", Category = "Category 1", Description ="Description 3", Price = 30m},
                new Product { ProductID =4, Name ="Product 4", Category = "Category 2", Description ="Description 4", Price = 40m},
                new Product { ProductID =5, Name ="Product 5", Category = "Category 2", Description ="Description 5", Price = 50m},
                new Product { ProductID =6, Name ="Product 6", Category = "Category 2", Description ="Description 6", Price = 50m}
            };
                //We are Delaying the Execution for 1 Seconds to get the Data from the database
                await Task.Delay(TimeSpan.FromSeconds(1));
                return products.Take(count).ToList();
            }
        }

        //The Invoke method for the View component
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            // Your logic for preparing data
            ProductRepository productRepository = new ProductRepository();
            var products = await productRepository.GetTopProductsAsync(count);
            return View(products);
        }
        //public IViewComponentResult Invoke(int count)
        //{
        // // Your logic for preparing data
        // ProductRepository productRepository = new ProductRepository();
        // var products = productRepository.GetTopProductsAsync(count).Result;
        // return View(products);
        //}
    }
}
