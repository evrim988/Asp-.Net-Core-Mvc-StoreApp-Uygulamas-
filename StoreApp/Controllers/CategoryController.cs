﻿using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetListCategories(false);
            return View(model);
        }
    }
}
