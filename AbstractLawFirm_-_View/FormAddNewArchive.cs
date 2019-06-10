﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractLawFirm___ServiceDAL.BindingModel;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___View
{
    public partial class FormAddNewArchive : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormAddNewArchive()
        {
            InitializeComponent();
        }
        private void FormArchive_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ArchiveViewModel view = APIClient.GetRequest<ArchiveViewModel>("api/Archive/Get/" + id.Value);
                    if (view != null)
                    {
                     textBoxName.Text = view.ArchiveName;
                        dataGridView.DataSource = view.ArchiveComponent;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode =
                       DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<ArchiveBindingModel, bool>("api/Archive/UpdElement", new ArchiveBindingModel
                    {
                        Id = id.Value,
                        ArchiveName = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<ArchiveBindingModel, bool>("api/Archive/AddElement", new ArchiveBindingModel
                    {
                        ArchiveName = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
