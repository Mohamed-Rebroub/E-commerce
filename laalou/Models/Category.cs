using System;
using System.Collections.Generic;

namespace laalou.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Photo { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}
