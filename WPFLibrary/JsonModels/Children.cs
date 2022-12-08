using System.ComponentModel.DataAnnotations.Schema;

namespace WPFLibrary.JsonModels;

public class Children 
{
    public int ChildrenId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public int GradeID { get; set; }
    public int ParentID { get; set; }
}

public class ChildrenView
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public GradeView Grade { set; get; }
    public UserView Parent { set; get; }
}

public class ChildrenInfo : BaseModel
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }

}