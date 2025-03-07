
//hội đồng bảo vệ đồ án tốt nghiệp.
namespace VicemMVCIdentity.Models.Graduation
{
    public class DefenseCommittee
{
    public int CommitteeID { get; set; } //mã hội đồng
    public string CommitteeName { get; set; }//tên hội đồng
    public int SessionID { get; set; }//mã đợt
    public int ChairpersonID { get; set; }//chủ tịch hội đồng
    public int SecretaryID { get; set; }//thư ký hội đồng
    public int Member1ID { get; set; }//thành viên 1
    public int Member2ID { get; set; }//thành viên 2
    public int? Member3ID { get; set; }//thành viên 3
    public GraduationSession GraduationSession { get; set; }
    public Lecturer Chairperson { get; set; }
    public Lecturer Secretary { get; set; }
    public Lecturer Member1 { get; set; }
    public Lecturer Member2 { get; set; }
    public Lecturer Member3 { get; set; }
}
}