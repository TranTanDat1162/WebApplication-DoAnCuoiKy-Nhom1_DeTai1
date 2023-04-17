﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Nhom1_DeTai1.Data;
using Nhom1_DeTai1.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Nhom1_DeTai1.Controllers
{
    public class AccountController : Controller
    {
        private readonly Nhom1_DeTai1Context _context;

        public AccountController(Nhom1_DeTai1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("UserID,UserName,UserEmail,UserPassword,UserRole")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User _userFromPage)
        {
            var _user = _context.User.Where(m => m.UserEmail == _userFromPage.UserEmail && m.UserPassword == _userFromPage.UserPassword).FirstOrDefault();
            if (_user == null)
            {
                ViewBag.LoginStatus = 0;
                GlobalVariables.MyGlobalVariable = false;
            }
            else
            {
                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, _user.UserEmail),
                    new Claim("FullName", _user.UserName),
                    new Claim(ClaimTypes.Role, _user.UserRole),
                    new Claim(ClaimTypes.NameIdentifier, _user.UserID.ToString()),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var authProperties = new AuthenticationProperties
                {

                };
                Thread.CurrentPrincipal = claimsPrincipal;
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal,
                    authProperties);
                GlobalVariables.MyGlobalVariable = true;
                GlobalVariables.CurrentPrinciple = claimsPrincipal;
                return RedirectToAction("Index", "Account");

            }
            return View();
        }
        public IActionResult Logout()
        {
            GlobalVariables.MyGlobalVariable = false;
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Account");
        }

        // GET: Users/Create
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("UserID,UserName,UserEmail,UserPassword,UserRole")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
