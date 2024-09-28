using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RishtaWebApp.Models
{
    public class PersonDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string? RegistrationNo { get; set; }
        public string? Name { get; set; }
        public string? Parantage { get; set; }
        public int GenderId { get; set; }
        public int NationalityId { get; set; }
        public int MotherLanguageId { get; set; }
        public int MaritalStatusId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public int BodyTypeId { get; set; }
        public int ComplexId { get; set; }
        public int QualificationId { get; set; }
        public int CasteId { get; set; }
        public string? SubCaste { get; set; }
        public int SectId { get; set; }
        public string? JobPosition { get; set; }
        public int MonthlyIncome { get; set; }
        public string? NatureOfJob { get; set; }
        public string? FuturePlans { get; set; }
        public string? FatherOccupation { get; set; }
        public string? MotherOccupation { get; set; }
        public int Brothers { get; set; }
        public int Sisters { get; set; }
        public int DependsSibling { get; set; }
        public int BrSisMarried { get; set; }
        public string? KidsDetail { get; set; }
        public string? HomeDistricts { get; set; }
        public string? Residence { get; set; }
        public int HouseId { get; set; }
        public string? Contact { get; set; }
        public string? OtherProperties { get; set; }
        public int Age { get; set; }
        public decimal ReqHeight { get; set; }
        public int ReqCasteId { get; set; }
        public int ReqSectId { get; set; }
        public int ReqMaritalStatusId { get; set; }
        public string? City { get; set; }
        public int ReqNationalityId { get; set; }
        public string? Job { get; set; }
        public int ReqQualificationId { get; set; }
        public int Income { get; set; }
    }
}
