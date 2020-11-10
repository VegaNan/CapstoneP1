using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore;
using AspNetCore.Identity.Mongo.Model;
using AspNetCore.Identity.Mongo.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using VegaN_Capstone.Data;
using VegaN_Capstone.Interfaces;
using VegaN_Capstone.Models;

namespace VegaN_Capstone.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IDal dal;
        private readonly UserManager<MongoUser> _userManager;
        private readonly RoleManager<MongoRole> _roleManager;

        public AdminController(
            UserManager<MongoUser> userManager,
            RoleManager<MongoRole> roleManager,
            IDal dal)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.dal = dal;
        }

        //this checks if the user is an admin
        private async Task<bool> IsAdmin()
        {

            MongoRole role = await _roleManager.FindByNameAsync("Admin");
            await _roleManager.AddClaimAsync(role, new Claim("Permission", "Manage"));
            MongoUser user = _userManager.GetUserAsync(User).Result;

            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                return true;
            }

            return false;
        }

        public IActionResult Index()
        {
            if (IsAdmin().Result)
            {
                return View();
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }


        [HttpGet]
        public IActionResult GetAllItems()
        {
            if (IsAdmin().Result)
            {
                return View(model: dal.GetItems());
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpGet]
        public IActionResult ItemTypeFilter(IEnumerable<String> types)
        {
            if (IsAdmin().Result)
            {
                return View();
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpGet]
        public IActionResult SearchItem(string containsString)
        {
            if (IsAdmin().Result)
            {
                return View();
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpGet]
        public IActionResult AddItem()
        {
            if (IsAdmin().Result)
            {
                return View();
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (IsAdmin().Result)
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
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpGet]
        public IActionResult ViewItem(string id)
        {
            if (IsAdmin().Result && (dal.GetItem(id) != null))
            {
                return View(model: dal.GetItem(id));
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }

        [HttpPost]
        public IActionResult UpdateItem(Item item)
        {
            if (IsAdmin().Result && (dal.GetItem(item.ID) != null))
            {
                dal.UpdateItem(item);
                return ViewItem(item.ID);
            }
            return RedirectToAction(actionName: "index", controllerName: "home");

        }
        [HttpPost]
        public IActionResult DeleteItem(string id)
        {
            if (IsAdmin().Result && (dal.GetItem(id) != null))
            {
                dal.DeleteItem(id);
                return ViewItem(id);
            }
            return RedirectToAction(actionName: "index", controllerName: "home");

        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            if (IsAdmin().Result)
            {
                return View("AdminUsers", model: dal.GetUsers());
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpGet]
        public IActionResult SearchUserByName(string containsString)
        {
            if (IsAdmin().Result)
            {
                IEnumerable<MongoUser> users = dal.GetUsers().Where(U => U.Email.Contains(containsString));
                return View("AdminUsers", model:users);
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpGet]
        public IActionResult NewUser()
        {
            if (IsAdmin().Result)
            {
                return View(model: new MongoUser());
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpPost]
        public IActionResult AddUser(MongoUser user)
        {
            if (IsAdmin().Result)
            { 
                dal.AddUser(user);
                return View("AdminUsers", model: new MongoUser());
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpPost]
        public IActionResult UpdateUser(MongoUser user)
        {
            if (IsAdmin().Result)
            {
                dal.UpdateUser(user);
                return View("AdminUsers", model: new MongoUser());
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
        }
        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            if (IsAdmin().Result)
            {
                dal.DeleteUser(id);
                return View("AdminUsers", model: new MongoUser());
            }
            return RedirectToAction(actionName: "index", controllerName: "home");
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
