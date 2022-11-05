using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFLibrary.JsonModels;

public class Timing : BaseModel
{
    public TimeSpan Time { get; set; }
    public int TypeId { get; set; }
    public int GradleId { get; set; }
}

public class TimingView
{
    public TimeSpan Time { get; set; }
    public string TypeMeal { get; set; }
    public GradeView Grade { get; set; }
}