using System.ComponentModel.DataAnnotations;

namespace VicemMVCIdentity.Models.Graduation{
public class GraduationProject
{
    [Key]
    public int ProjectID { get; set; }//mã đồ án
    public int StudentID { get; set; }//mã sv
    public int LecturerID { get; set; }//mã giảng viên hd
    public string ProjectTitleVN { get; set; }//tên đồ án bằng tiếng việt
    public string ProjectTitleEN { get; set; }// tên đồ án bằng tiếng anh
    public DateTime StartDate { get; set; }//ngày bắt đầu
    public DateTime EndDate { get; set; }//ngày kết thúc
    public string Status { get; set; }//trạng thái đồ án
    public Student Student { get; set; }
}
}
// thông tin đồ án tốt nghiệp của sinh viên
