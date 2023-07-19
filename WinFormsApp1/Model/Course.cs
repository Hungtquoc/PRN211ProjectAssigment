using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Course
{
    public string Id { get; set; } = null!;

    public string Cname { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
