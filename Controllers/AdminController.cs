using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using VegaN_Capstone.Data;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDal dal;

        public AdminController(IDal dal)
        {
            this.dal = dal;

        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAllItems()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ItemTypeFilter(IEnumerable<String> types)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SearchItem(string containsString)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (HttpContext.Request.Form.Files != null)
            {
                var files = HttpContext.Request.Form.Files;
                List<Image> images = item.Images.ToList<Image>();

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        images.Add(Image.FromStream(file.OpenReadStream()));
                    }
                }
            }

            return View();
        }
        [HttpGet]
        public IActionResult ViewItem(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateItem(Item item)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SearchUserByName(string containsString)
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(MongoUser user)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewUser(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(MongoUser user)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SearchBookingByDate(DateTime startDate, DateTime endDate)
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewBooking()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewBooking(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBooking(Booking booking)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteBooking(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllAnnouncements()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ViewAnnouncement(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteAnnouncement(int id)
        {
            return View();
        }


    }

}
