using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RishtaWebApp.Data;
using RishtaWebApp.Models;
using RishtaWebApp.ViewModels;

namespace RishtaWebApp.Controllers
{
    public class LookUpController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LookUpController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public async Task<LookUpVM> EditLookUp(int id)
        {
            LookUpVM obj = await (from a in _context.LookUps
                                  where a.Id == id
                                  select new LookUpVM
                                  {
                                      Id=a.Id,
                                      TypeId = a.TypeId,
                                      LookUpNames = a.Name,


                                  }
                         ).FirstOrDefaultAsync();
            return obj;
        }


        [HttpPost]
        public async Task<JsonResult> UpSert([FromBody] LookUpVM obj)
        {
            int id = Convert.ToInt32(obj.Id);
            var result =  _context.LookUps.Find(id);
            if(result!=null)
            {
                result.TypeId = obj.TypeId;
                result.Name = obj.LookUpNames;
                    
            }
            else
            {
                var checkIfExists = await _context.LookUps.Where(x => x.TypeId == obj.TypeId && x.Name == obj.LookUpNames).ToListAsync();
                if(checkIfExists.Count>0)
                {
                    return new JsonResult("Record Already Exists......");
                }
                else
                {
                    var lkOjb = new LookUp()
                    {
                        TypeId=obj.TypeId,
                        Name=obj.LookUpNames,
                    };
                    _context.LookUps.Add(lkOjb);
                }

            }
                _context.SaveChanges();
                return new JsonResult("Data Submitted Successfully.....");

            
        }
        [HttpGet]
        public async Task<IHttpActionResult> getLookUpData(int? Id)
        {
            var LookUps = await (from a in _context.LookUps
                                 where a.TypeId==Id
                            orderby a.Id ascending
                            select new LookUpVM
                            {
                                Id = a.Id,
                                TypeId = a.TypeId,
                                LookUpNames = a.Name

                            }).ToListAsync();

            return new IHttpActionResult
            {
                recordsTotal = LookUps.Count(),
                recordsFiltered = 10,
                data = LookUps.ToArray()
            };
        }
        public Object LookUpTypes()
        {
            return (_context.LookUps.Select(x => new
            {
                Id = x.Id,
                TypeId = x.TypeId,
                Name = x.Name,
            }).ToList().Where(x => x.TypeId == 0));
        }
    }
}
