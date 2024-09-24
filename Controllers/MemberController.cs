using Microsoft.AspNetCore.Mvc;
using RishtaWebApp.Data;
using RishtaWebApp.ViewModels;

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

        [HttpPost]
        public async Task<JsonResult> InsertStudent(MemberFormViewModel memberObj)
        {
            JsonResponseViewModel modal = new JsonResponseViewModel();
            modal.ResponseCode = 0;
            modal.ResponseMessage = "Api End working fine";

            return  Json(modal);
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

