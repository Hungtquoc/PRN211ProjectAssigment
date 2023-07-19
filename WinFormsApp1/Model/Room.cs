using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Room
{
    public string Id { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
}
