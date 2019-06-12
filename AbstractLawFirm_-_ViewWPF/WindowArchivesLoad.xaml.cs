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
using Microsoft.Win32;

namespace AbstractLawFirm___ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для WindowArchivesLoad.xaml
    /// </summary>
    public class Row {
        public String archiveName { get; set; }
        public String blankName { get; set; }
        public String count { get; set; }
    }
    public partial class WindowArchivesLoad : Window
    {
        public WindowArchivesLoad()
        {
            InitializeComponent();
        }

        private void ButtonSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    APIClient.PostRequest<ReportBindingModel, bool>("api/Report/SaveStoksLoad", new ReportBindingModel
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ArchiveLoadViewModel> dict = APIClient.GetRequest<List<ArchiveLoadViewModel>>("api/Archive/GetList");
                if (dict != null)
                {
                    dataGridView.Items.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Items.Add(new Row() { archiveName = elem.ArchiveName, blankName = "", count = "" });
                        foreach (var listElem in elem.Blanks)
                        {
                            dataGridView.Items.Add(new Row() { archiveName = "", blankName = listElem.Item1.ToString(), count = listElem.Item2.ToString()});
                        }
                        dataGridView.Items.Add(new Row() { archiveName = "Итого: ", blankName = "", count = elem.TotalCount.ToString() });
                        dataGridView.Items.Add(new Row() { archiveName = "", blankName = "", count = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}
