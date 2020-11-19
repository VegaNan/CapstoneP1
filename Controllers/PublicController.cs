using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using VegaN_Capstone.Data;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;


namespace VegaN_Capstone.Controllers
{
    public class PublicController : Controller
    {
        private readonly SqlServerDBDal dal;

        public PublicController(SqlServerDBDal dal)
        {
            this.dal = dal;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> items = dal.GetItems().Result;
            return View("ItemsView", model : items);
        }
        [HttpGet]
        public IActionResult  GetItem(int id)
        {
            return View("ViewSingleItem", model: dal.GetItem(id));
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
        [HttpGet]
        public IActionResult NewBooking()
        {
            Booking b = new Booking();
            return View("AddBooking", model:b);
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            dal.AddBooking(booking);
            return View();
        }

        [HttpPost]
        public IActionResult AddToBooking(string id)
        {
            
            return View();
        }

    }
}
