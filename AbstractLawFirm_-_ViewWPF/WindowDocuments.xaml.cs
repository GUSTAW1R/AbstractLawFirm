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
    /// Логика взаимодействия для WindowDocuments.xaml
    /// </summary>
    public partial class WindowDocuments : Window
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<DocumentBlankViewModel> documentsComponent;

        public WindowDocuments()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowDocumentsComponent();
            if (window.ShowDialog() == true)
            {
                if (window.Model != null)
                {
                    if (id.HasValue)
                    {
                        window.Model.DocumentsId = id.Value;
                    }
                    documentsComponent.Add(window.Model);
                }
                LoadData();
            }
        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DocumentsViewModel view = APIClient.GetRequest<DocumentsViewModel>("api/Documents/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.DocumentsName;
                        textBoxSum.Text = view.Price.ToString();
                        documentsComponent = view.DocumentBlank;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                documentsComponent = new List<DocumentBlankViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (documentsComponent != null)
                {
                    dateGridView.ItemsSource = null;
                    dateGridView.ItemsSource = documentsComponent;
                    dateGridView.Columns[0].Visibility = Visibility.Hidden;
                    dateGridView.Columns[1].Visibility = Visibility.Hidden;
                    dateGridView.Columns[2].Visibility = Visibility.Hidden;
                    dateGridView.Columns[3].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dateGridView.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        documentsComponent.RemoveAt(dateGridView.SelectedIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (dateGridView.SelectedItems.Count == 1)
            {
                var window = new WindowDocumentsComponent();
                window.Model = documentsComponent[dateGridView.SelectedIndex];
                if (window.ShowDialog() == true)
                {
                    documentsComponent[dateGridView.SelectedIndex] = window.Model;
                    LoadData();
                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (documentsComponent == null || documentsComponent.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                List<DocumentBlankBindingModel> documentsComponentBM = new List<DocumentBlankBindingModel>();
                for (int i = 0; i < documentsComponent.Count; ++i)
                {
                    documentsComponentBM.Add(new DocumentBlankBindingModel
                    {
                        Id = documentsComponent[i].Id,
                        DocumentsId = documentsComponent[i].DocumentsId,
                        BlankId = documentsComponent[i].BlankId,
                        Count = documentsComponent[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APIClient.PostRequest<DocumentsBindingModel, bool>("api/Documents/UpdElement", new DocumentsBindingModel
                    {
                        Id = id.Value,
                        DocumentsName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxSum.Text),
                        DocumentBlank = documentsComponentBM
                    });
                }
                else
                {
                    APIClient.PostRequest<DocumentsBindingModel, bool>("api/Documents/AddElement", new DocumentsBindingModel
                    {
                        DocumentsName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxSum.Text),
                        DocumentBlank = documentsComponentBM
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

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
