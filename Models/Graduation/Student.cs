
namespace   VicemMVCIdentity.Models.Graduation
{
    public class Student 
    {
    public int StudentID { get; set; }
    public string FullName { get; set; }//họ tên
    public DateTime DateOfBirth { get; set; }//ngày tháng năm sinh
    public string PhoneNumber { get; set; }//sđt
    public string Email { get; set; }//gmail
    public string Major { get; set; }//lớp
    public string Faculty { get; set; }//khoa
    public string Course { get; set; }//khóa
    public ICollection<GraduationProject> GraduationProjects { get; set; }
}
}
// thông tin cá nhân của sinh viên