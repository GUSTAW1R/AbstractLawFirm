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
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;
using Unity;

namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly IMainService service;

        public MainWindow(IMainService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void LoadData()
        {
            try
            {
                List<OrderViewModel> list = service.GetList();
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

        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowCreateOrder>();
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
                    service.TakeOrderInWork(new OrderBindingModel { Id = id });
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
                    service.FinishOrder(new OrderBindingModel { Id = id });
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
                    service.PayOrder(new OrderBindingModel { Id = id });
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
            var window = Container.Resolve<WindowBlankList>();
            window.ShowDialog();
        }

        private void документыToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowDocumentsList>();
            window.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowCustomerList>();
            window.ShowDialog();
        }

        private void архивыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<WindowArchiveList>();
            form.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
                var form = Container.Resolve<WindowPutOnArchive>();
                form.ShowDialog();
            
        }
    }
}
