using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Group
{
    public int Id { get; set; }

    public int? Lectureid { get; set; }

    public string? Courseid { get; set; }

    public string? Gname { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();

    public virtual ICollection<Student> Sids { get; } = new List<Student>();
}
