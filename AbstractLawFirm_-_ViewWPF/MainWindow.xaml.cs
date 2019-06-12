using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;


namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = APIClient.GetRequest<List<OrderViewModel>>("api/Main/GetList");
                if (list != null)
                {
                    dataGridView.ItemsSource = list;
                    dataGridView.Columns[0].Visibility = Visibility.Hidden;
                    dataGridView.Columns[1].Visibility = Visibility.Hidden;
                    dataGridView.Columns[3].Visibility = Visibility.Hidden;
                    dataGridView.Columns[5].Visibility = Visibility.Hidden;
                    dataGridView.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowCreateOrder();
            window.ShowDialog();
            LoadData();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItem != null)
            {
                int id = ((OrderViewModel)dataGridView.SelectedItem).Id;
                try
                {
                    APIClient.PostRequest<OrderBindingModel, bool>("api/Main/TakeOrderInWork", new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItems != null)
            {
                int id = ((OrderViewModel)dataGridView.SelectedItem).Id;
                try
                {
                    APIClient.PostRequest<OrderBindingModel, bool>("api/Main/FinishOrder", new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItems.Count != null)
            {
                int id = ((OrderViewModel)dataGridView.SelectedItem).Id;
                try
                {
                    APIClient.PostRequest<OrderBindingModel, bool>("api/Main/PayOrder", new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        private void бланкиToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowBlankList();
            window.ShowDialog();
        }

        private void документыToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowDocumentsList();
            window.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowCustomerList();
            window.ShowDialog();
        }

        private void архивыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new WindowArchiveList();
            form.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
                var form = new WindowPutOnArchive();
                form.ShowDialog();
            
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    APIClient.PostRequest<ReportBindingModel, bool>("api/Report/SaveDocumentsPrice", new ReportBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new WindowArchivesLoad();
            window.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            var window = new WindowCustomerOrder();
            window.ShowDialog();
        }
    }
}
