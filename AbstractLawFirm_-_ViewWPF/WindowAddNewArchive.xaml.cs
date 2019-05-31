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
    /// Логика взаимодействия для WindowAddNewArchive.xaml
    /// </summary>
    public partial class WindowAddNewArchive : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IArchiveService service;
        private int? id;

        public WindowAddNewArchive(IArchiveService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ArchiveViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.ArchiveName;
                        dataGridView.ItemsSource = view.ArchiveComponent;
                        dataGridView.Columns[0].Visibility = Visibility.Hidden;
                        dataGridView.Columns[1].Visibility = Visibility.Hidden;
                        dataGridView.Columns[2].Visibility = Visibility.Hidden;
                        dataGridView.Columns[3].Width =
                       DataGridLength.Auto;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new ArchiveBindingModel
                    {
                        Id = id.Value,
                        ArchiveName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new ArchiveBindingModel
                    {
                        ArchiveName = textBoxName.Text
                    });
                }
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

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
