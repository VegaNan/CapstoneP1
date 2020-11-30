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
using VegaN_Capstone.Helper;
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
            Item i = dal.GetItem(id).Result;
            return View("ViewSingleItem", model: i);
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
            List<Item> Items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if(Items!= null && Items.Count()> 0)
            {
                b.Items = Items;
            }
            return View("AddBooking", model:b);
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                Booking finalBooking = dal.GetBooking(dal.AddBooking(booking).Result);
                return View(model:finalBooking);
            }
            else
            {
                List<Item> Items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

                if (Items != null && Items.Count() > 0)
                {
                    booking.Items = Items;
                }
                return View("AddBooking", model: booking);
            }
        }

        [HttpPost]
        public IActionResult AddItemToBooking(int id)
        {
            Item i = dal.GetItem(id).Result;
            List<Item> cartItems = new List<Item>();
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (!(cart == null) && !(cart.Count == 0))
            {
                cartItems = cart;
            }
            cartItems.Add(i);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartItems);
            ViewBag.cart = cartItems.ToArray();
            return Index();
        }

    }
}
