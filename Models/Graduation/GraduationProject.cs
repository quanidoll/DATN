using System.ComponentModel.DataAnnotations;

namespace VicemMVCIdentity.Models.Graduation{
public class GraduationProject
{
    [Key]
    public int ProjectID { get; set; }
    public int StudentID { get; set; }
    public int LecturerID { get; set; }
    public string ProjectTitleVN { get; set; }
    public string ProjectTitleEN { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public Student Student { get; set; }
}
}

