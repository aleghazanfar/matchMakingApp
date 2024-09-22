namespace RishtaWebApp.Models
{
    public class PersonOrg
    {

        public int Id { get; set; }
        public int? PersonOrgType { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
