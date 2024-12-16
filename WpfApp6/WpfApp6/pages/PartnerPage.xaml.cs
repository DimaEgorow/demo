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
    /// Логика взаимодействия для PartnerPage.xaml
    /// </summary>
    public partial class PartnerPage : Page
    {
        public PartnerPage()
        {
            InitializeComponent();
            CmbSort.SelectedIndex = 0;
            CmbFilter.SelectedIndex = 0;
            GetData(TbSearch.Text, CmbSort.Text, CmbFilter.Text);
            HistoryBtn.Click += HistoryBtn_Click;
            CalcBtn.Click += CalcBtn_Click;
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pages.CalculateCountProduct());
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedPartner = (Models.Partner)LvAgents.SelectedItem;
            if (selectedPartner != null)
            {
                NavigationService.Navigate(new pages.HistoryPages(selectedPartner));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите партнера для просмотра истории продаж.");
            }
        }

        int skip = 0;
        int take = 10;
        int countAfter = 0;

        private void GetData(string search = "", string sort = "", string filter = "")
        {
            sPanel.Children.Clear();

            // Используем Include для загрузки связанных данных
            var data = App.DB.Partners
                .Include(p => p.PartnerProducts)
                .ThenInclude(pp => pp.PartnerProductNavigation) // Загружаем ProductImport
                .ToList();

            int countBefore = data.Count;
            data = data.Where(c => c.NamePartner.ToLower().Contains(search.ToLower()) || c.Email.ToLower().Contains(search.ToLower())).ToList();

            if (filter != "Все типы")
            {
                data = data.Where(c => c.TypePartner == filter).ToList();
            }

            if (CmbSort.SelectedIndex == 0)
                data = data.OrderBy(x => x.NamePartner).ToList();
            if (CmbSort.SelectedIndex == 1)
                data = data.OrderByDescending(x => x.NamePartner).ToList();

            countAfter = data.Count;

         
            data = data.Skip(skip).Take(take).ToList();
            LvAgents.ItemsSource = data;
            int currentCount = 0;
            if (take + skip < countAfter)
                currentCount = take + skip;
            else
                currentCount = countAfter;
            counts.Text = $"{currentCount} из {countAfter}";
        }
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            skip = 0;
            GetData(TbSearch.Text, CmbSort.Text, CmbFilter.Text);

        }
        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            skip = 0;
            GetData(TbSearch.Text, ((ComboBoxItem)CmbSort.SelectedItem).Content.ToString(), CmbFilter.Text);
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            skip = 0;
            GetData(TbSearch.Text, CmbSort.Text, ((ComboBoxItem)CmbFilter.SelectedItem).Content.ToString());
        }

        private void LvAgents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.Mode = 2;
            App.currentPatner = (Models.Partner)LvAgents.SelectedItem;
            NavigationService.Navigate(new pages.AddEditDelPartner());
        }

        private void BtnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            App.Mode = 1;
            var addEditPage = new pages.AddEditDelPartner();
            addEditPage.PartnerSaved += OnPartnerSaved; // Подписываемся на событие
            NavigationService.Navigate(addEditPage);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            skip -= take;
            if (skip < 0)
            {
                System.Windows.MessageBox.Show("Начало списка");
                skip += take;
            }
            GetData(TbSearch.Text, CmbSort.Text, CmbFilter.Text);
        }
        private void OnPartnerSaved()
        {
   
            GetData(TbSearch.Text, CmbSort.Text, CmbFilter.Text); // Обновление данных
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            skip += take;
            if (skip < 0)
            {
                System.Windows.MessageBox.Show("Конец Списка");
                skip -= take;
            }
            GetData(TbSearch.Text, CmbSort.Text, CmbFilter.Text);
        }
    }
}
