using System;
using System.Collections.Generic;

namespace Stokdbf.data.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
