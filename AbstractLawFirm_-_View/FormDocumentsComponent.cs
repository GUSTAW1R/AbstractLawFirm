﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractLawFirm___ServiceDAL.Interfaces;
using AbstractLawFirm___ServiceDAL.ViewModel;

namespace AbstractLawFirm___View
{
    public partial class FormDocumentsComponent : Form
    {
        public DocumentBlankViewModel Model { set { model = value; } get { return model; } }
        private DocumentBlankViewModel model;

        public FormDocumentsComponent()
        {
            InitializeComponent();
        }
        private void FormProductComponent_Load(object sender, EventArgs e)
        {
            try
            {
                List<BlankViewModel> list = APIClient.GetRequest<List<BlankViewModel>>("api/Blank/GetList");
                if (list != null)
                {
                    comboBoxDocumentsComponent.DisplayMember = "BlankName";
                    comboBoxDocumentsComponent.ValueMember = "Id";
                    comboBoxDocumentsComponent.DataSource = list;
                    comboBoxDocumentsComponent.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxDocumentsComponent.Enabled = false;
                comboBoxDocumentsComponent.SelectedValue = model.BlankId;
                textBoxCount.Text = model.Count.ToString();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDocumentsComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
