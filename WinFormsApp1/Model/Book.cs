using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model;

public partial class Book
{
    public string Name { get; set; } = null!;

    public int Cateid { get; set; }

    public double Priceperunit { get; set; }

    public int Unit { get; set; }

    public int Id { get; set; }

    public virtual Category Cate { get; set; } = null!;
}
