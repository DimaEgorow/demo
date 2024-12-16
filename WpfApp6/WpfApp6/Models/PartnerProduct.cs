using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int PartnerProductId { get; set; }

    public int PartnerId { get; set; }

    public int CountProduct { get; set; }

    public DateTime DateSale { get; set; }

    public virtual Partner Partner { get; set; } = null!;

    public virtual ProductImport PartnerProductNavigation { get; set; } = null!;
}
