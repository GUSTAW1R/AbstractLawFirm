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

namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowAddNewCustomer.xaml
    /// </summary>
    public partial class WindowAddNewCustomer : Window
    {
        public int Id { set { id = value; } }
        private int? id;

        public WindowAddNewCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load()
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel view = APIClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.CustomerFIO;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest <CustomerBindingModel, bool>("api/Customer/UpdElement", new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerFIO = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/AddElement", new CustomerBindingModel
                    {
                        CustomerFIO = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            FormCustomer_Load();
        }
    }
}
