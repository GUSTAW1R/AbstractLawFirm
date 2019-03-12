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
    public partial class FormPutOnArchive : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IArchiveService serviceS;
        private readonly IBlankService serviceC;
        private readonly IMainService serviceM;
        public FormPutOnArchive(IArchiveService serviceS, IBlankService serviceC, IMainService serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }
        private void FormPutOnArchive_Load(object sender, EventArgs e)
        {
            try
            {
                List<BlankViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxComponents.DisplayMember = "BlankName";
                    comboBoxComponents.ValueMember = "Id";
                    comboBoxComponents.DataSource = listC;
                    comboBoxComponents.SelectedItem = null;
                }
                List<ArchiveViewModel> listS = serviceS.GetList();
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
                serviceM.PutComponentsOnArchive(new ArchiveComponentBindingModel
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
