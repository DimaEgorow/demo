using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6.pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryPages.xaml
    /// </summary>
    public partial class HistoryPages : Page
    {
        public HistoryPages(Models.Partner selectedPartner)
        {
            InitializeComponent();
            LoadSalesHistory(selectedPartner);
        }

        private void LoadSalesHistory(Models.Partner partner)
        {
            var salesHistory = App.DB.PartnerProducts
                .Include(pp => pp.PartnerProductNavigation) // Загружаем информацию о продукте
                .Where(pp => pp.PartnerId == partner.Id)
                .ToList();

            if (salesHistory.Any())
            {
                LvSalesHistory.ItemsSource = salesHistory;
                LvSalesHistory.Visibility = System.Windows.Visibility.Visible;
                NoSalesMessage.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                LvSalesHistory.Visibility = System.Windows.Visibility.Collapsed;
                NoSalesMessage.Visibility = System.Windows.Visibility.Visible;
            }
        }

    }
}
