using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SonOfCod.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SonOfCod.Controllers
{
    [Authorize]
    public class MailingListController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public MailingListController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        //Create Contact
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
           contact.User = currentUser;
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Contacts.Where(x => x.User.Id == currentUser.Id));
        }
    }
}
