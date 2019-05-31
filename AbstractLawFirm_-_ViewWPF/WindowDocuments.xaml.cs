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
    /// Логика взаимодействия для WindowDocuments.xaml
    /// </summary>
    public partial class WindowDocuments : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDocumentsService service;
        private int? id;
        private List<DocumentBlankViewModel> documentsComponent;

        public WindowDocuments(IDocumentsService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowDocumentsComponent>();
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
                    DocumentsViewModel view = service.GetElement(id.Value);
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
                        documentsComponent.RemoveAt(dateGridView.SelectedItems[0].Cells[0].RowIndex);
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
                var window = Container.Resolve<WindowDocumentsComponent>();
                window.Model = documentsComponent[dateGridView.SelectedRows[0].Cells[0].RowIndex];
                if (window.ShowDialog() == true)
                {
                    documentsComponent[dateGridView.SelectedRows[0].Cells[0].RowIndex] = window.Model;
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
                    service.UpdElement(new DocumentsBindingModel
                    {
                        Id = id.Value,
                        DocumentsName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxSum.Text),
                        DocumentBlank = documentsComponentBM
                    });
                }
                else
                {
                    service.AddElement(new DocumentsBindingModel
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
