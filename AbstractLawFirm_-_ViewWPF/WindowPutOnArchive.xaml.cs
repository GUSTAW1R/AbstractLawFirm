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
    /// Логика взаимодействия для WindowPutOnArchive.xaml
    /// </summary>
    public partial class WindowPutOnArchive : Window
    {

        public WindowPutOnArchive()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (comboBoxBlank.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (comboBoxArchive.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<ArchiveComponentBindingModel, bool>("api/Main/PutComponentOnStock", new ArchiveComponentBindingModel
                {
                    BlankId = Convert.ToInt32(comboBoxBlank.SelectedValue),
                    ArchiveId = Convert.ToInt32(comboBoxArchive.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BlankViewModel> listC = APIClient.GetRequest<List<BlankViewModel>>("api/Blank/GetList");
                if (listC != null)
                {
                    comboBoxBlank.DisplayMemberPath = "BlankName";
                    comboBoxBlank.SelectedValuePath = "Id";
                    comboBoxBlank.ItemsSource = listC;
                    comboBoxBlank.SelectedItem = null;
                }
                List<ArchiveViewModel> listS = APIClient.GetRequest<List<ArchiveViewModel>>("api/Archive/GetList");
                if (listS != null)
                {
                    comboBoxArchive.DisplayMemberPath = "ArchiveName";
                    comboBoxArchive.SelectedValuePath = "Id";
                    comboBoxArchive.ItemsSource = listS;
                    comboBoxArchive.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
