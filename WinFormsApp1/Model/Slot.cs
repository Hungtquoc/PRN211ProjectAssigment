using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Slot
{
    public int Id { get; set; }

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
}
