using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFLibrary.JsonModels;

public class Timing
{
    public int TimingId { get; set; }
    public DateTime Time { get; set; }
    public int TypeMelId { get; set; }
    public int GradeId { get; set; }
}

public class TimingView
{
    public TimeSpan Time { get; set; }
    public string TypeMeal { get; set; }
    public GradeView Grade { get; set; }
}