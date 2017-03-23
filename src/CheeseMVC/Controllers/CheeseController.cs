using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {



        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {

            /* This is more or less what the model binding is doing automagically 
             * for us in this Cheese/Add action
             * 
             Cheese newCheese = new Cheese();
             newCheese.Name = Request.get("name");
             newCheese.Description = Request.get("description");
             */

            // Add the new cheese to my existing cheeses
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            // TODO - remove cheeses from list
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);

            }
            return Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.cheeses = CheeseData.GetById(id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, string description)
        {
            ViewBag.cheeses = CheeseData.GetById(id);
            CheeseData.Edit(name, description);
            return Redirect("/");
        }
    }
}
