using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class TypeProduct
{
    public int Id { get; set; }

    public string TypeProduct1 { get; set; } = null!;

    public double PercentMarriage { get; set; }

    public virtual ICollection<ProductImport> ProductImports { get; set; } = new List<ProductImport>();
}
