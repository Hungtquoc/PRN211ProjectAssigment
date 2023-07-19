using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Lecture
{
    public int Id { get; set; }

    public string Lname { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
