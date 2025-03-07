namespace   VicemMVCIdentity.Models.Graduation
{
    public class SupervisorAssignment
{
    public int AssignmentID { get; set; }
    public int StudentID { get; set; }
    public int LecturerID { get; set; }
    public DateTime AssignmentDate { get; set; } = DateTime.Now;
    public Student Student { get; set; }
    public Lecturer Lecturer { get; set; }
}
}
//thông tin phân công giảng viên hướng dẫn sinh viên