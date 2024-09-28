using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RishtaWebApp.Data;
using RishtaWebApp.Models;
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
        public async Task<JsonResult> InsertMemberDetail([FromBody] MemberFormViewModel obj)
        {
            var result = await _context.PersonDetails.FirstOrDefaultAsync(x => x.Id == obj.Id);
            if (result == null)
            {
                result = new PersonDetail();
                result.Id = obj.Id;
                _context.PersonDetails.Add(result);
            }
            result.Name = obj.Name;
            result.Parantage = obj.Parantage;
            result.GenderId = obj.GenderId;
            result.NationalityId = obj.NationalityId;
            result.MotherLanguageId = obj.MotherLanguageId;
            result.MaritalStatusId = obj.MaritalStatusId;
            result.DateOfBirth = obj.DateOfBirth;
            result.Height = obj.Height;
            result.BodyTypeId = obj.BodyTypeId;
            result.ComplexId = obj.ComplexId;
            result.QualificationId = obj.QualificationId;
            result.CasteId = obj.CasteId;
            result.SubCaste = obj.SubCaste;
            result.SectId = obj.SectId;
            result.JobPosition = obj.JobPosition;
            result.MonthlyIncome = obj.MonthlyIncome;
            result.NatureOfJob = obj.NatureOfJob;
            result.FuturePlans = obj.FuturePlans;
            result.FatherOccupation = obj.FatherOccupation;
            result.MotherOccupation = obj.MotherOccupation;
            result.Brothers = obj.Brothers;
            result.Sisters = obj.Sisters;
            result.DependsSibling = obj.DependsSibling;
            result.BrSisMarried = obj.BrSisMarried;
            result.KidsDetail = obj.KidsDetail;
            result.HomeDistricts = obj.HomeDistricts;
            result.Residence = obj.Residence;
            result.HouseId = obj.HouseId;
            result.Contact = obj.Contact;
            result.OtherProperties = obj.OtherProperties;
            result.Age = obj.Age;
            result.ReqHeight = obj.ReqHeight;
            result.ReqCasteId = obj.ReqCasteId;
            result.ReqSectId = obj.ReqCasteId;
            result.ReqMaritalStatusId = obj.ReqMaritalStatusId;
            result.City = obj.City;
            result.ReqNationalityId = obj.ReqNationalityId;
            result.Job = obj.Job;
            result.ReqQualificationId = obj.ReqQualificationId;
            result.Income = obj.Income;
            _context.SaveChanges();

            JsonResponseViewModel modal = new JsonResponseViewModel();
            modal.ResponseCode = 0;
            modal.ResponseMessage = "Member's Form Submitted Successfully";

            return  Json(modal);
        }
        [HttpPost]
        public async Task<JsonResult> NewMemberInsert([FromBody] MemberFormViewModel obj)
        {
            var result = await _context.PersonDetails.FirstOrDefaultAsync(x => x.Id == obj.Id);
            if (result == null)
            {
                result = new PersonDetail();
                result.Id = obj.Id;
                _context.PersonDetails.Add(result);
            }
            result.Name = obj.Name;
            result.Parantage = obj.Parantage;
           
            _context.SaveChanges();

            JsonResponseViewModel modal = new JsonResponseViewModel();
            modal.ResponseCode = 0;
            modal.ResponseMessage = "Member's Form Submitted Successfully";

            return Json(modal);
        }


        [HttpGet]
        public IActionResult NewMemberInsert(int? id)
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
        [HttpGet]
        public object GetNextmisId()
        {
            return (_context.GetNextMemberSeqId());
        }
        public JsonResult GetmisId()
        {
           // int misId =Convert.ToInt16(GetNextMemberSeqId());
            int misId = _context.GetNextMemberSeqId();
            return Json(misId);
        }
    }
}

