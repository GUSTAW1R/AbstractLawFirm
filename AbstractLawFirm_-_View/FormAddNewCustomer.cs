using System;
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
using AbstractLawFirm___ServiceDAL.BindingModel;
using System.Text.RegularExpressions;

namespace AbstractLawFirm___View
{
    public partial class FormAddNewCustomer : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public FormAddNewCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel client = APIClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + id.Value);
                    textBoxFIO.Text = client.CustomerFIO;
                    textBoxMail.Text = client.Mail;
                    dataGridView.DataSource = client.Messages;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            string fio = textBoxFIO.Text;
            string mail = textBoxMail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-
!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9az][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (id.HasValue)
            {
                APIClient.PostRequest<CustomerBindingModel,
               bool>("api/Customer/UpdElement", new CustomerBindingModel
               {
                   Id = id.Value,
                   CustomerFIO = fio,
                   Mail = mail
               });
            }
            else
            {
                APIClient.PostRequest<CustomerBindingModel,
               bool>("api/Customer/AddElement", new CustomerBindingModel
               {
                   CustomerFIO = fio,
                   Mail = mail
               });
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
