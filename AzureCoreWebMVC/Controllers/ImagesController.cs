﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureCoreWebMVC.Models;
using AzureCoreWebMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureCoreWebMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class ImagesController : Controller
    {
        private readonly ImageStore imageStore;

        public ImagesController(ImageStore imageStore)//ImageStore imageStore
        {
            this.imageStore = imageStore;// new ImageStore();// imageStore;
        }
        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            if (image != null)
            {
                using (var stream = image.OpenReadStream())
                {
                    var imageId = await imageStore.SaveImage(stream);
                    return RedirectToAction("Show", new { imageId });
                }
            }
            return View();
        }

        [HttpGet("{imageId}")]
        public ActionResult Show(string imageId)
        {
            var model = new ShowModel { Uri = imageStore.UriFor(imageId) };
            return View(model);
        }
        // GET: Images/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Images/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Images/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Images/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Images/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}