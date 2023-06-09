﻿using System.Reflection.Metadata.Ecma335;
using System.Web;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationdbContext _db;
        public CategoryController(ApplicationdbContext db  )
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() 
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Create(Category obj) 
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
           
            if(ModelState.IsValid) 
            { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
             TempData["Success"] = "Category Created Successfully";   
             return RedirectToAction("Index");
            }
            return View();
           
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
           // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
           // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj) 
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost ,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        
        }


    }
}





