using AutoMapper;
using Lesson26InClass.Database;
using Lesson26InClass.Database.Entities;
using Lesson26InClass.Models;
using Lesson26InClass.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson26InClass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly AsparagusDB _db;
        public HomeController(ILogger<HomeController> logger, IMapper mapper, AsparagusDB db)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AsparagusIDto dto)
        {
            _db.Asparagus.Add(_mapper.Map<Asparagus>(dto));
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            var s = _db.Asparagus.GroupBy(e => e.Email)
                .Select(e => 
                $"{e.Max(e => e.SendTime)} - {e.OrderByDescending(e=>e.SendTime).First().Name} съел спаржу {e.Count()} раз(а)")
                .ToList();
            return View(s);
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