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
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;


namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowDocumentsComponent.xaml
    /// </summary>
    public partial class WindowDocumentsComponent : Window
    {
        public DocumentBlankViewModel Model { set { model = value; } get { return model; } }
        private DocumentBlankViewModel model;

        public WindowDocumentsComponent()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxDocumentsComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new DocumentBlankViewModel
                    {
                        BlankId = Convert.ToInt32(comboBoxDocumentsComponent.SelectedValue),
                        BlankName = comboBoxDocumentsComponent.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BlankViewModel> list = APIClient.GetRequest<List<BlankViewModel>>("api/Blank/GetList");
                if (list != null)
                {
                    comboBoxDocumentsComponent.DisplayMemberPath = "BlankName";
                    comboBoxDocumentsComponent.SelectedValuePath = "Id";
                    comboBoxDocumentsComponent.ItemsSource = list;
                    comboBoxDocumentsComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (model != null)
            {
                comboBoxDocumentsComponent.IsEnabled = false;
                comboBoxDocumentsComponent.SelectedValue = model.BlankId;
                textBoxCount.Text = model.Count.ToString();
            }
        }

        private void ButtonCancel_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
