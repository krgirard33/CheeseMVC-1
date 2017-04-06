using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.Controllers;
using CheeseMVC.Data;
using System.Linq;

namespace CheeseMVC.ViewModels
{
    public class AllCheesesViewModel
    {
        private CheeseDbContext context;

        public AllCheesesViewModel(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public List<Cheese> Cheeses { get; set; }

        public AllCheesesViewModel()
        {
            Cheeses = context.Cheeses.ToList();
        }
    }
}
