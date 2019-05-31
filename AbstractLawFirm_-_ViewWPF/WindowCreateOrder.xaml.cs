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
using System.Windows.Shapes;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;
using Unity;

namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowCreateOrder.xaml
    /// </summary>
    public partial class WindowCreateOrder : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ICustomerService serviceC;
        private readonly IDocumentsService serviceD;
        private readonly IMainService serviceM;

        public WindowCreateOrder(ICustomerService serviceC, IDocumentsService serviceD, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceD = serviceD;
            this.serviceM = serviceM;
        }

        private void FormCreateOrder_Load()
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxClient.DisplayMemberPath = "CustomerFIO";
                    comboBoxClient.SelectedValuePath = "Id";
                    comboBoxClient.ItemsSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
                List<DocumentsViewModel> listP = serviceD.GetList();
                if (listP != null)
                {
                    comboBoxDocument.DisplayMemberPath = "DocumentsName";
                    comboBoxDocument.SelectedValuePath = "Id";
                    comboBoxDocument.ItemsSource = listP;
                    comboBoxDocument.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxDocument.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxDocument.SelectedValue);
                    DocumentsViewModel product = serviceD.GetElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxDocument.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
                return;
            }
            try
            {
                serviceM.CreateOrder(new OrderBindingModel
                {
                    CustomerId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    DocumentsId = Convert.ToInt32(comboBoxDocument.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            FormCreateOrder_Load();
        }

        private void ComboBoxDocument_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcSum();
        }

        private void TextBoxSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcSum();
        }
    }
}
