using System;
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
using Unity;

namespace AbstractLawFirm___View
{
    public partial class FormDocuments : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IDocumentsService service;
        private int? id;
        private List<DocumentBlankViewModel> documentsComponent;

        public FormDocuments(IDocumentsService service)
        {
            InitializeComponent();
            this.service = service;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DocumentsViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.DocumentsName;
                        textBoxPrice.Text = view.Price.ToString();
                        documentsComponent = view.DocumentBlank;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = documentsComponent;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDocumentsComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.DocumentsId = id.Value;
                    }
                    documentsComponent.Add(form.Model);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDocumentsComponent>();
                form.Model = documentsComponent[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    documentsComponent[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.Model;
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                    documentsComponent.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (documentsComponent == null || documentsComponent.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        DocumentBlank = documentsComponentBM
                    });
                }
                else
                {
                service.AddElement(new DocumentsBindingModel
                {
                    DocumentsName = textBoxName.Text,
                    Price = Convert.ToInt32(textBoxPrice.Text),
                    DocumentBlank = documentsComponentBM
                });
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
