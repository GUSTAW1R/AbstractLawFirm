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

namespace AbstractLawFirm___View
{
    public partial class FormPutOnArchive : Form
    {
        public FormPutOnArchive()
        {
            InitializeComponent();
        }
        private void FormPutOnArchive_Load(object sender, EventArgs e)
        {
            try
            {
                List<BlankViewModel> listC = APIClient.GetRequest<List<BlankViewModel>>("api/Blank/GetList");
                if (listC != null)
                {
                    comboBoxComponents.DisplayMember = "BlankName";
                    comboBoxComponents.ValueMember = "Id";
                    comboBoxComponents.DataSource = listC;
                    comboBoxComponents.SelectedItem = null;
                }
                List<ArchiveViewModel> listS = APIClient.GetRequest<List<ArchiveViewModel>>("api/Archive/GetList");
                if (listS != null)
                {
                    comboBoxArchives.DisplayMember = "ArchiveName";
                    comboBoxArchives.ValueMember = "Id";
                    comboBoxArchives.DataSource = listS;
                    comboBoxArchives.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponents.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxArchives.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<ArchiveComponentBindingModel, bool>("api/Archive/AddElement", new ArchiveComponentBindingModel
                {
                    BlankId = Convert.ToInt32(comboBoxComponents.SelectedValue),
                    ArchiveId = Convert.ToInt32(comboBoxArchives.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
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
