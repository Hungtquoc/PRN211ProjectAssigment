using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Student
{
    public int Id { get; set; }

    public string Sname { get; set; } = null!;

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
