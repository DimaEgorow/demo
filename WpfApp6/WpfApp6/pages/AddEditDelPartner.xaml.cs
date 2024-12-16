using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditDelPartner.xaml
    /// </summary>
    public partial class AddEditDelPartner : Page
    {

        public event Action PartnerSaved;
        private List<string> partnerTypes = new List<string>
        {
            "ООО",
            "ОАО",
            "ПАО",
            "ЗАО"
        };

        private Models.Partner partner;

        public AddEditDelPartner()
        {
            InitializeComponent();
            partner = new Models.Partner();

            if (App.Mode == 2 && App.currentPatner != null)
            {
                partner = App.DB.Partners.FirstOrDefault(x => x.Id == App.currentPatner.Id);
                Title = "Редактировать партнера";
            }
            else
            {
                Title = "Добавить партнера";
            }

            DataContext = partner;


            CbType.ItemsSource = partnerTypes.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка на заполненность обязательных полей
                if (string.IsNullOrWhiteSpace(partner.NamePartner) ||
                    string.IsNullOrWhiteSpace(partner.TypePartner) ||
                    string.IsNullOrWhiteSpace(partner.Rating.ToString()) ||
                    string.IsNullOrWhiteSpace(partner.AddressPartner) ||
                    string.IsNullOrWhiteSpace(partner.Director) ||
                    string.IsNullOrWhiteSpace(partner.NumberPhone) ||
                    string.IsNullOrWhiteSpace(partner.Email) ||
                    string.IsNullOrWhiteSpace(partner.Inn.ToString()))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка формата электронной почты
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(partner.Email, emailPattern))
                {
                    MessageBox.Show("Неправильный формат электронной почты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка длины ИНН
                string innString = partner.Inn.ToString();
                if (innString.Length != 10 && innString.Length != 12)
                {
                    MessageBox.Show("ИНН должен содержать 10 или 12 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка диапазона рейтинга
                if (partner.Rating < 1 || partner.Rating > 10)
                {
                    MessageBox.Show("Рейтинг должен быть в диапазоне от 1 до 10.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка на пустой адрес
                if (string.IsNullOrWhiteSpace(partner.AddressPartner))
                {
                    MessageBox.Show("Адрес партнера не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (App.Mode == 1)
                {
                    App.DB.Partners.Add(partner);
                    MessageBox.Show("Партнер добавлен успешно.");
                }
                else if (App.Mode == 2)
                {
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные партнера обновлены успешно.");
                }

                App.DB.SaveChanges();
                PartnerSaved?.Invoke();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
