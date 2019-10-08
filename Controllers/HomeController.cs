using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefDish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ChefDish.Controllers
{
    public class HomeController : Controller
    {
        private Context _db;
        public HomeController(Context Context)
        {
            _db = Context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("Chefs");
        }
        [HttpGet("chefs")]
        public IActionResult Chefs()
        {
            List<Chef> AllChefs = _db.Chefs.Include(c => c.Dishes).ToList();
            return View(AllChefs);
        }
        [HttpGet("chefs/new")]
        public IActionResult ChefForm()
        {
            return View();
        }
        [HttpPost("chefs/new")]
        public IActionResult NewChef(Chef form)
        {
            if(ModelState.IsValid)
            {
                _db.Add(form);
                _db.SaveChanges();
                return RedirectToAction("Chefs");
            }
            return View("ChefForm");
        }
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = _db.Dishes.Include(dish => dish.Chef).ToList();
            return View(AllDishes);
        }
        [HttpGet("dishes/new")]
        public IActionResult DishForm()
        {
            ChefsDish formobject = new ChefsDish();
            List<Chef> AllChefs = _db.Chefs.ToList();
            formobject.Chefs = AllChefs;
            return View(formobject);
        }
        [HttpPost("dishes/new")]
        public IActionResult NewDish(ChefsDish form)
        {
            if(ModelState.IsValid)
            {
                _db.Add(form.Dish);
                _db.SaveChanges();
                return RedirectToAction("Dishes");
            }
            ChefsDish formobject = new ChefsDish();
            List<Chef> AllChefs = _db.Chefs.ToList();
            formobject.Chefs = AllChefs;
            return View("DishForm", formobject);
        }
    }
}
