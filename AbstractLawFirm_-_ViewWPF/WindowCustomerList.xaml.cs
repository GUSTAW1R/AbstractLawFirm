﻿using System;
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
    /// Логика взаимодействия для WindowCustomerList.xaml
    /// </summary>
    public partial class WindowCustomerList : Window
    {

        public WindowCustomerList()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                List<CustomerViewModel> list = APIClient.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if (list != null)
                {
                    dataGridView.ItemsSource = list;
                    dataGridView.Columns[0].Visibility = Visibility.Hidden;
                    dataGridView.Columns[1].Width = DataGridLength.Auto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddNewCustomer();
            if (window.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridView.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = ((CustomerViewModel)dataGridView.SelectedItem).Id;
                    try
                    {
                        APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/DelElement", new CustomerBindingModel { Id = id });
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
            if (dataGridView.SelectedItems.Count == 1)
            {
                var form = new WindowAddNewCustomer();
                form.Id = ((CustomerViewModel)dataGridView.SelectedItem).Id;
                if (form.ShowDialog() == true)
                {
                    LoadData();
                }
            }
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}