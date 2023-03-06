using AspMvcConferenceEkzamen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AspMvcConferenceEkzamen.Controllers
{
    public class HomeController : Controller
    {
        AplicationContext db = new AplicationContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewConference view = new ViewConference();
            view.ArConference = await db.Conferences.ToListAsync();
            return View("Index", view);
        }
        public IActionResult CreateConference()
        {
            return View("CreateConference");
        }
        public IActionResult CreateUser(ViewConference co)
        {
            ViewModel view = new ViewModel();
            view.Conf = co.Conferenc;
            return View("CreateUser", view);
        }
        public async Task<IActionResult> AddConference(Conference conf)
        {
                db.Conferences.Add(conf);
                db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddUser(ViewModel view)
        {
            view.Conf.Users = new List<User>();
            view.Conf.Users.Add(view.Usr);

            db.Users.Add(view.Usr);
            db.Conferences.Remove(view.Conf);
            db.SaveChanges();           
            db.Conferences.Add(view.Conf);
            db.SaveChanges();
            return View("UserComplete", view.Conf);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}