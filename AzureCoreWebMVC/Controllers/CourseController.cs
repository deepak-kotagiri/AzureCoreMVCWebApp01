using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureCoreWebMVC.Models;
using AzureCoreWebMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureCoreWebMVC.Controllers
{
    public class CourseController : Controller
    {
        public CourseStore _coursedb;
        public CourseController()
        {
            _coursedb = new CourseStore();
        }
        // GET: Course
        public ActionResult Index()
        {
         var courses=  _coursedb.GetCourses();
            return View(courses);
        }

        // GET: Course/Details/5
        public  ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Course/Create
        public async Task<ActionResult> Create()
        {
            var courses=  Getcourses();
             await _coursedb.InsertCourses(courses);

            return View("Index");
        }

        private List<Course> Getcourses()
        {
            var courses = new List<Course>()
            {
                 new Course()
                 {
                       Id="11",
                       Title="Title 1",
                       Modules= new List<Module>
                       {
                             new Module{
                                 Title ="Module 11", Clips= new List<Clip>()
                                 {
                                      new Clip()    {  Name="Clip 11", Length=100  },
                                       new Clip()    {  Name="Clip 111", Length=100  },
                                        new Clip()    {  Name="Clip 11111", Length=100  },
                                         new Clip()    {  Name="Clip 111111", Length=100  },
                                          new Clip()    {  Name="Clip 111111", Length=100  }
                                 }
                             }
                       }
                 },
                 new Course()
                 {
                       Id="12",
                       Title="Title 12",
                       Modules= new List<Module>
                       {
                             new Module{
                                 Title ="Module 12", Clips= new List<Clip>()
                                 {
                                      new Clip()
                                      {
                                           Name="Clip 122", Length=200

                                      },
                                       new Clip()
                                      {
                                           Name="Clip 123", Length=200

                                      },
                                        new Clip()
                                      {
                                           Name="Clip 124", Length=200

                                      }
                                 }
                             }
                       }
                 },
                 new Course()
                 {
                       Id="13",
                       Title="Title 13",
                       Modules= new List<Module>
                       {
                             new Module{
                                 Title ="Module 13", Clips= new List<Clip>()
                                 {
                                      new Clip()
                                      {
                                           Name="Clip 13", Length=300

                                      }
                                 }
                             },
                              new Module{
                                 Title ="Module 133", Clips= new List<Clip>()
                                 {
                                      new Clip()
                                      {
                                           Name="Clip 133", Length=300

                                      },
                                       new Clip()
                                      {
                                           Name="Clip 134", Length=300

                                      }
                                 }
                             }
                       }
                 }


            };
            return courses;
        }

        // POST: Course/Create
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

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
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

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
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