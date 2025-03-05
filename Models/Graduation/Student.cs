
namespace   VicemMVCIdentity.Models.Graduation
{
    public class Student 
    {
    public int StudentID { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Major { get; set; }
    public string Faculty { get; set; }
    public string Course { get; set; }
    public ICollection<GraduationProject> GraduationProjects { get; set; }
}

}