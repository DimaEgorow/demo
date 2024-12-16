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
    /// Логика взаимодействия для CalculateCountProduct.xaml
    /// </summary>
    public partial class CalculateCountProduct : Page
    {
        public CalculateCountProduct()
        {
            InitializeComponent();
            LoadTypeProducts();
            LoadTypeMaterials();
        }

        private void LoadTypeProducts()
        {
            var typeProducts = App.DB.TypeProducts.ToList();
            TypeProductComboBox.ItemsSource = typeProducts;
            TypeProductComboBox.DisplayMemberPath = "TypeProduct1"; 
            TypeProductComboBox.SelectedValuePath = "Id"; 
        }

        private void LoadTypeMaterials()
        {
            var typeMaterials = App.DB.TypeMaterials.ToList();
            TypeMaterialComboBox.ItemsSource = typeMaterials;
            TypeMaterialComboBox.DisplayMemberPath = "TypeMaterial1";
            TypeMaterialComboBox.SelectedValuePath = "Id"; 
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из текстовых полей и ComboBox
            if (TypeProductComboBox.SelectedValue is int typeProductId &&
                int.TryParse(QuantityTextBox.Text, out int quantity) &&
                TypeMaterialComboBox.SelectedValue is int typeMaterialId &&
                double.TryParse(Parameter1TextBox.Text, out double parameter1) &&
                double.TryParse(Parameter2TextBox.Text, out double parameter2))
            {
                // Вызываем метод для расчета необходимого материала
                int requiredMaterial = CalculateRequiredMaterial(typeProductId, typeMaterialId, quantity, parameter1, parameter2);

                // Отображаем результат
                if (requiredMaterial == -1)
                {
                    ResultTextBlock.Text = "Ошибка: Неправильные данные.";
                }
                else
                {
                    ResultTextBlock.Text = $"Необходимое количество материала: {requiredMaterial}";
                }
            }
            else
            {
                ResultTextBlock.Text = "Ошибка: Пожалуйста, введите корректные данные.";
            }
        }

        private int CalculateRequiredMaterial(int typeProductId, int typeMaterialId, int quantity, double parameter1, double parameter2)
        {
            // Проверка на положительность параметров
            if (quantity <= 0 || parameter1 <= 0 || parameter2 <= 0)
            {
                return -1; // Неподходящие данные
            }

            // Получаем тип продукции из базы данных
            var typeProduct = App.DB.TypeProducts.Find(typeProductId);
            if (typeProduct == null)
            {
                return -1; // Не существует типа продукции
            }

            // Получаем тип материала из базы данных
            var typeMaterial = App.DB.TypeMaterials.Find(typeMaterialId);
            if (typeMaterial == null)
            {
                return -1; // Не существует типа материала
            }

            // Расчет необходимого материала на одну единицу продукции
            double materialPerUnit = parameter1 * parameter2 * typeProduct.PercentMarriage;

            // Учитываем процент брака материала
            double totalMaterial = materialPerUnit * quantity * (1 + typeMaterial.PercentMarriage / 100);

            // Возвращаем целое количество необходимого материала
            return (int)Math.Ceiling(totalMaterial); // Округляем до ближайшего целого
        }
    }
}
