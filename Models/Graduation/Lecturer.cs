namespace   VicemMVCIdentity.Models.Graduation{
public class Lecturer
{
    public int LecturerID { get; set; }
    public string FullName { get; set; }//họ tên
    public string LecturerCode { get; set; }//mã giảng viên
    public string PhoneNumber { get; set; }//sđt
    public string Email { get; set; }//gmail
    public string Faculty { get; set; }//khoa
    public ICollection<SupervisorAssignment> SupervisorAssignments { get; set; }
    public ICollection<GraduationProject> GraduationProjects { get; set; }
}
}
//   Thông tin cá nhân của giảng viên
