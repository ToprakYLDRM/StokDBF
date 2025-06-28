using System;
using System.Collections.Generic;

namespace Stokdbf.data.Models;

public partial class StockMovement
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string MovementType { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime MovementDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
