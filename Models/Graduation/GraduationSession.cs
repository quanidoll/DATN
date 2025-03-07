namespace VicemMVCIdentity.Models.Graduation
{
    public class GraduationSession
{
    public int SessionID { get; set; }//mã đợt
    public string SessionName { get; set; }//tên đợt
    public string AcademicYear { get; set; }//năm bao nhiêu
    public string Semester { get; set; }//học kỳ mấy
    public DateTime StartDate { get; set; }// ngày bắt đầu
    public DateTime EndDate { get; set; }// ngày kết thúc
}
}
// đợt làm đồ án tốt nghiệp