using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VegaN_Capstone.Data;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Controllers
{
    public class PublicController : Controller
    {
        private readonly IDal dal;

        public PublicController(IDal dal)
        {
            this.dal = dal;
        }

        public IActionResult Index()
        {
            return View("ItemsView", model : dal.GetItems());
        }
        [HttpGet]
        public IActionResult  GetItem(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult TypeFilter(IEnumerable<string> types)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Search(string containsString)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBooking(Booking booking)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            return View();
        }


    }
}
