using Microsoft.AspNetCore.Mvc;
using RishtaWebApp.Data;

namespace RishtaWebApp.Controllers
{
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpSert(int? id)
        {
            return View();
        }

        public Object LookUpTypes(int id)
        {
            return (_context.LookUps.Select(x => new
            {
                Id = x.Id,
                TypeId = x.TypeId,
                Name = x.Name,
            }).ToList().Where(x => x.TypeId == id));
        }
    }
}

