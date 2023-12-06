using Interview_API_Project.Models;
using Interview_API_Project.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text; 
using System.Data;
using System.Net.Http; 
using System.Diagnostics; 
using Microsoft.Extensions.Logging; 
using System.Globalization; 
using System.Security.Cryptography; 
using Newtonsoft.Json; 
using System.Xml.Linq;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Interview_API_Project.Controllers
{

    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: /User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: /User/All
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        // POST: /User/Update
        public async Task<IActionResult> Update(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var result = await _userService.UpdateUserAsync(user);
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Details", new { id = user.Id });
        }

        // POST: /User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result == "User not found")
            {
                return NotFound();
            }
            return RedirectToAction("All");
        }

        // POST: /User/FindOldestUser
        public async Task<IActionResult> FindOldestUser(int id)
        {
            return null; 
        }

        // GET: /User/ByRole/Admin
        public async Task<IActionResult> ByRole(string role)
        {
            var users = await _userService.GetUsersWithSpecificRole(role);
            return View("UsersByRole", users);
        }

        // GET: /User/ResetPassword/5
        public async Task<IActionResult> ResetPassword(int id)
        {
            var result = await _userService.ResetUserPassword(id);
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Details", new { id = id });
        }

    }

}
