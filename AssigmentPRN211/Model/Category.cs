using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; } = new List<Book>();
}
