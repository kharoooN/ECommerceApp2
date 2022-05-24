﻿using ECommerceApp.Business.Abstract;
using ECommerceApp.Entities;
using ECommerceApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }

        //products/telefon?page=2
        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentCategory = category
                }
            });
        }
    }
}