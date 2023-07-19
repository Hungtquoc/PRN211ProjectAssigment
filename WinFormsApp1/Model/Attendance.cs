using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Attendance
{
    public int Aid { get; set; }

    public int Sesid { get; set; }

    public int Sid { get; set; }

    public bool? Checked { get; set; }

    public virtual Session Ses { get; set; } = null!;

    public virtual Student SidNavigation { get; set; } = null!;
}
