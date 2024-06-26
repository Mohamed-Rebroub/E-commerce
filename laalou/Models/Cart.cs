using System;
using System.Collections.Generic;

namespace laalou.Models;

public partial class Cart
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Qty { get; set; }

    public virtual Produit? Product { get; set; }

    internal void AddToCart(int productId, int quantity)
    {
        throw new NotImplementedException();
    }
}
