using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Session
{
    public int Id { get; set; }

    public int Gid { get; set; }

    public int Timeid { get; set; }

    public string Roomid { get; set; } = null!;

    public int Lid { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual Group GidNavigation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Slot Time { get; set; } = null!;
}
