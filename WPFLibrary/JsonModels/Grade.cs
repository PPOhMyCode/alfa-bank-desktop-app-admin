using System.ComponentModel.DataAnnotations.Schema;

namespace WPFLibrary.JsonModels;

public class Grade: BaseModel
{
    public string Name { get; set; }
    public int TeacherID { get; set; }
}

public class GradeView 
{
    public string Name { get; set; }
    public UserView Teacher { get; set; }
}
