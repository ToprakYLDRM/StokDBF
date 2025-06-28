using System;
using System.Collections.Generic;

namespace Stokdbf.data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<StockMovement> StockMovements { get; } = new List<StockMovement>();

    public virtual Supplier Supplier { get; set; } = null!;
}
