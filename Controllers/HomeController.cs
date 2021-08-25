using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeddingPlan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlan.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in Use!");
                    return View("Index");
                }else{
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("loggedIn", newUser.UserId);
                    return RedirectToAction("Dashboard");
                }
            }else{
                return View("Index");
            }
        }
        

        [HttpPost("login")]
        public IActionResult Login(LogUser logUser)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(u => u.Email == logUser.LogEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                    return View("Index");
                    }else{
                        PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>(); var Result = Hasher.VerifyHashedPassword(logUser, userInDb.Password, logUser.LogPassword);
                        if(Result == 0)
                        {
                            ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                            return View("Index");
                        }
                        HttpContext.Session.SetInt32("loggedIn", userInDb.UserId);
                        return RedirectToAction("Dashboard");
                    }
            }else{
                return View("Index");
            }
        }

        [HttpGet("dahboard")]
        public IActionResult Dashboard()
        {
            int? loggedIn = HttpContext.Session.GetInt32("loggedIn");
            if(loggedIn != null)
            {
                ViewBag.OtherWeddings = _context.Weddings.Where(q => q.UserId !=(int)loggedIn).Include(d => d.GuestAttending).ToList();
                ViewBag.Users = _context.Users.Include(w => w.AllWeddings).ThenInclude(d => d.GuestAttending).FirstOrDefault(a => a.UserId == (int)loggedIn);
                return View();
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {
            int? loggedIn = HttpContext.Session.GetInt32("loggedIn");
            if(loggedIn != null)
            {
                ViewBag.Users = _context.Users.Include(w => w.AllWeddings).ThenInclude(d => d.GuestAttending).FirstOrDefault(a => a.UserId == (int)loggedIn);
                return View();
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("AddWedding")]
        public IActionResult AddWedding()
        {
            return View();
        }

        [HttpPost("AddWeddingToDb")]
        public IActionResult AddWeddingToDb(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                newWedding.UserId = (int)HttpContext.Session.GetInt32("loggedIn");
                _context.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("DashBoard");
            } else{
                return View("AddWedding");
            }
        }

        [HttpGet("rsvp/{UserId}/{WeddingId}")]

        public IActionResult RSVP(int UserId, int WeddingId)
        {
            int? loggedIn = HttpContext.Session.GetInt32("loggedIn");
            if(loggedIn != null)
            {
                if((int) loggedIn != UserId)
                {
                    return RedirectToAction("LogOut");
                } else{
                    Guest newGuest = new Guest();
                    newGuest.UserId = UserId;
                    newGuest.WeddingId = WeddingId;
                    _context.Guests.Add(newGuest);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("norsvp/{UserId}/{WeddingId}")]

        public IActionResult NoRSVP(int UserId, int WeddingId)
        {
            int? loggedIn = HttpContext.Session.GetInt32("loggedIn");
            if(loggedIn != null)
            {
                if((int) loggedIn != UserId)
                {
                    return RedirectToAction("LogOut");
                } else{
                    Guest Guestnorsvp = _context.Guests.FirstOrDefault(b => b.WeddingId == WeddingId && b.UserId == UserId);
                    _context.Guests.Remove(Guestnorsvp);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("/delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
            Wedding WeddingToDelete = _context.Weddings.SingleOrDefault(y => y.WeddingId == WeddingId);
            _context.Remove(WeddingToDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/OneWedding/{WeddingId}")]
        public IActionResult OneWedding(int WeddingId)
        {
            int? loggedIn = HttpContext.Session.GetInt32("loggedIn");
            if(loggedIn != null)
            {
                ViewBag.OtherWeddings = _context.Weddings.Where(q => q.UserId !=(int)loggedIn).Include(d => d.GuestAttending).ToList();
                return View("OneWedding");
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
