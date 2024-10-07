using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RishtaWebApp.Data;
using RishtaWebApp.Models;
using RishtaWebApp.ViewModels;
using System.Linq.Dynamic.Core;
using System.IO;

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
                result.RegistrationNo = obj.RegistrationNo;
                _context.PersonDetails.Add(result);
            }
            result.Name = obj.Name;
            result.Parantage = obj.Parantage;
            result.GenderId = obj.GenderId;
            result.NationalityId = obj.NationalityId;
            result.MotherLanguageId = obj.MotherLanguageId;
            result.MaritalStatusId = obj.MaritalStatusId;
            result.DateOfBirth = Convert.ToDateTime(obj.DateOfBirth);
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
            result.ReqSectId = obj.ReqSectId;
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

            return Json(modal);
        }

        //get list of members

        [HttpPost]
        public JsonResult GetMembersList()
        {
            int totalRecord = 0;
            int filterRecord = 0;

            var draw = Request.Form["draw"].FirstOrDefault();


            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();


            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();


            var searchValue = Request.Form["search[value]"].FirstOrDefault();


            int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");


            int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

            var data = (from a in _context.PersonDetails
                        join gender in _context.LookUps on a.GenderId equals gender.Id
                        orderby a.Id ascending
                        select new MemberFormViewModel
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Parantage = a.Parantage,
                            Gender = gender.Name,
                            JobPosition = a.JobPosition,

                        }).AsQueryable();


            //get total count of data in table
            totalRecord = data.Count();

            // search data when search value found
            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x =>
                  x.Name.ToLower().Contains(searchValue.ToLower())
                  || x.Gender.ToLower().Contains(searchValue.ToLower())
                  || x.Parantage.ToLower().Contains(searchValue.ToLower())
                  || x.Gender.ToLower().Contains(searchValue.ToLower())
                  || x.JobPosition.ToLower().Contains(searchValue.ToLower())

                );
            }
            // get total count of records after search 
            filterRecord = data.Count();
            //sort data
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
                data = data.OrderBy(sortColumn + " " + sortColumnDirection);

            //pagination
            var empList = data.Skip(skip).Take(pageSize).ToList();

            var returnObj = new { draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList };
            return Json(returnObj);


        }

        [HttpGet]
        public async Task<JsonResult> getMemberById(int? Id)
        {
            var obj = await _context.PersonDetails.FirstOrDefaultAsync(x => x.Id == Id);
            return Json(obj);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> MemberProfile(int? Id)
        {
            var data = await (from a in _context.PersonDetails
                              join gender in _context.LookUps on a.GenderId equals gender.Id
                              join nationality in _context.LookUps on a.NationalityId equals nationality.Id
                              join mrLangage in _context.LookUps on a.MotherLanguageId equals mrLangage.Id
                              join mrtStats in _context.LookUps on a.MaritalStatusId equals mrtStats.Id
                              join bdytype in _context.LookUps on a.BodyTypeId equals bdytype.Id
                              join cmplex in _context.LookUps on a.ComplexId equals cmplex.Id
                              join qlfction in _context.LookUps on a.QualificationId equals qlfction.Id
                              join sect in _context.LookUps on a.SectId equals sect.Id
                              join cst in _context.LookUps on a.CasteId equals cst.Id
                              join huse in _context.LookUps on a.HouseId equals huse.Id
                              join rqCst in _context.LookUps on a.ReqCasteId equals rqCst.Id
                              join reSect in _context.LookUps on a.ReqSectId equals reSect.Id
                              join remrtSts in _context.LookUps on a.ReqMaritalStatusId equals remrtSts.Id
                              join reNantionlty in _context.LookUps on a.ReqNationalityId equals reNantionlty.Id
                              join reqQlfon in _context.LookUps on a.ReqQualificationId equals reqQlfon.Id

                              where a.Id == Id
                              select new MemberFormViewModel
                              {
                                  Id = a.Id,
                                  RegistrationNo=a.RegistrationNo,
                                  Name = a.Name,
                                  Parantage = a.Parantage,
                                  Gender = gender.Name,
                                  Nationality = nationality.Name,
                                  MotherLanguage = mrLangage.Name,
                                  MaritalStatus = mrtStats.Name,
                                //  DateOfBirth = a.DateOfBirth.GetValueOrDefault().ToString("dd/MM/yyyy"),
                                 DateOfBirth = a.DateOfBirth.ToString("dd/MM/yyyy"),
                                  Height = a.Height,
                                  Bodytype = bdytype.Name,
                                  Complex = cmplex.Name,
                                  Qualification = qlfction.Name,
                                  Caste = cst.Name,
                                  SubCaste = a.SubCaste,
                                  Sect = sect.Name,
                                  JobPosition = a.JobPosition,
                                  MonthlyIncome = a.MonthlyIncome,
                                  NatureOfJob = a.NatureOfJob,
                                  FuturePlans = a.FuturePlans,
                                  FatherOccupation = a.FatherOccupation,
                                  MotherOccupation = a.MotherOccupation,
                                  Brothers = a.Brothers,
                                  Sisters = a.Sisters,
                                  DependsSibling = a.DependsSibling,
                                  BrSisMarried = a.BrSisMarried,
                                  KidsDetail = a.KidsDetail,
                                  HomeDistricts = a.HomeDistricts,
                                  Residence = a.Residence,
                                  House=huse.Name,
                                  Contact = a.Contact,
                                  OtherProperties = a.OtherProperties,
                                  Age = a.Age,
                                  ReqHeight = a.ReqHeight,
                                  ReqCaste = rqCst.Name,
                                  ReqSect = rqCst.Name,
                                  reqMaritalStatus = remrtSts.Name,
                                  City = a.City,
                                  ReqNationality = reNantionlty.Name,
                                  Job = a.Job,
                                  ReqQualification = reqQlfon.Name,
                                  Income = a.Income

                              }).FirstOrDefaultAsync();
            return Json(data);
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

