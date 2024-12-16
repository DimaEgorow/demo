using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class ProductImport
{
    public int Id { get; set; }

    public int TypeProductId { get; set; }

    public string NameProduct { get; set; } = null!;

    public int Articul { get; set; }

    public double Price { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual TypeProduct TypeProduct { get; set; } = null!;
}
