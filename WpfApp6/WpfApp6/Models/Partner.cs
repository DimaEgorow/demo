using System;
using System.Collections.Generic;

namespace WpfApp6.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string TypePartner { get; set; } = null!;

    public string NamePartner { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public string AddressPartner { get; set; } = null!;

    public long Inn { get; set; }

    public int Rating { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
    public double CalculateDiscount()
    {
        // Суммируем общую стоимость проданных товаров
        double totalSales = PartnerProducts.Sum(pp => pp.CountProduct * pp.PartnerProductNavigation.Price);

        // Определяем размер скидки
        if (totalSales < 10000)
            return 0;
        else if (totalSales < 50000)
            return 0.05; // 5%
        else if (totalSales < 300000)
            return 0.10; // 10%
        else
            return 0.15; // 15%
    }

    // Вычисляемое свойство для отображения скидки в процентах
    public string DiscountText => $"{CalculateDiscount() * 100}%";
}
