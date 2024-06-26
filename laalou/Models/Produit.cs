using System;
using System.Collections.Generic;

namespace laalou.Models;

public partial class Produit
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public decimal? Prix { get; set; }

    public int? Catid { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Cat { get; set; }
}
