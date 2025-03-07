
//kết quả bảo vệ đoán tốt nghiệp
namespace VicemMVCIdentity.Models.Graduation
{
    public class DefenseResult
{
    public int ResultID { get; set; }
    public int ProjectID { get; set; }//mã đồ án
    public int CommitteeID { get; set; }//mã hội đồng
    public DateTime DefenseDate { get; set; }//ngày bảo vệ
    public decimal Score { get; set; }//điểm
    public string Remarks { get; set; }//đánh giá nhận xét
    public GraduationProject GraduationProject { get; set; }
    public DefenseCommittee DefenseCommittee { get; set; }
}
}