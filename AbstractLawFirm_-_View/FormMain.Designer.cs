namespace AbstractLawFirm___View
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripLawFirm = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бланкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.архивыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсыДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьАрхивовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAddOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.menuStripLawFirm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripLawFirm
            // 
            this.menuStripLawFirm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.отчётностьToolStripMenuItem});
            this.menuStripLawFirm.Location = new System.Drawing.Point(0, 0);
            this.menuStripLawFirm.Name = "menuStripLawFirm";
            this.menuStripLawFirm.Size = new System.Drawing.Size(1209, 24);
            this.menuStripLawFirm.TabIndex = 0;
            this.menuStripLawFirm.Text = "menuStrip1";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.бланкиToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.архивыToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // бланкиToolStripMenuItem
            // 
            this.бланкиToolStripMenuItem.Name = "бланкиToolStripMenuItem";
            this.бланкиToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.бланкиToolStripMenuItem.Text = "Бланки";
            this.бланкиToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.документыToolStripMenuItem.Text = "Документы";
            this.документыToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // архивыToolStripMenuItem
            // 
            this.архивыToolStripMenuItem.Name = "архивыToolStripMenuItem";
            this.архивыToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.архивыToolStripMenuItem.Text = "Архивы";
            this.архивыToolStripMenuItem.Click += new System.EventHandler(this.архивыToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнениеToolStripMenuItem_Click);
            // 
            // отчётностьToolStripMenuItem
            // 
            this.отчётностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсыДокументовToolStripMenuItem,
            this.загруженностьАрхивовToolStripMenuItem,
            this.заказыКлиентовToolStripMenuItem});
            this.отчётностьToolStripMenuItem.Name = "отчётностьToolStripMenuItem";
            this.отчётностьToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.отчётностьToolStripMenuItem.Text = "Отчётность";
            // 
            // прайсыДокументовToolStripMenuItem
            // 
            this.прайсыДокументовToolStripMenuItem.Name = "прайсыДокументовToolStripMenuItem";
            this.прайсыДокументовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.прайсыДокументовToolStripMenuItem.Text = "Прайсы документов";
            this.прайсыДокументовToolStripMenuItem.Click += new System.EventHandler(this.прайсДокументовToolStripMenuItem_Click);
            // 
            // загруженностьАрхивовToolStripMenuItem
            // 
            this.загруженностьАрхивовToolStripMenuItem.Name = "загруженностьАрхивовToolStripMenuItem";
            this.загруженностьАрхивовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.загруженностьАрхивовToolStripMenuItem.Text = "Загруженность архивов";
            this.загруженностьАрхивовToolStripMenuItem.Click += new System.EventHandler(this.загруженностьАрхивовToolStripMenuItem_Click);
            // 
            // заказыКлиентовToolStripMenuItem
            // 
            this.заказыКлиентовToolStripMenuItem.Name = "заказыКлиентовToolStripMenuItem";
            this.заказыКлиентовToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.заказыКлиентовToolStripMenuItem.Text = "Заказы клиентов";
            this.заказыКлиентовToolStripMenuItem.Click += new System.EventHandler(this.заказыКлиентовToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 34);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1041, 494);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonAddOrder
            // 
            this.buttonAddOrder.Location = new System.Drawing.Point(1075, 34);
            this.buttonAddOrder.Name = "buttonAddOrder";
            this.buttonAddOrder.Size = new System.Drawing.Size(122, 54);
            this.buttonAddOrder.TabIndex = 2;
            this.buttonAddOrder.Text = "Оформить заказ на документ";
            this.buttonAddOrder.UseVisualStyleBackColor = true;
            this.buttonAddOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1075, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отдать на оформление";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1075, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 54);
            this.button2.TabIndex = 4;
            this.button2.Text = "Оформленный документ готов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1075, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 53);
            this.button3.TabIndex = 5;
            this.button3.Text = "Услуги по оформлению оплачены";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(1075, 474);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(122, 54);
            this.buttonUpd.TabIndex = 6;
            this.buttonUpd.Text = "Обновить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 540);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAddOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStripLawFirm);
            this.MainMenuStrip = this.menuStripLawFirm;
            this.Name = "FormMain";
            this.Text = "Абстрактная юридическая фирма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripLawFirm.ResumeLayout(false);
            this.menuStripLawFirm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripLawFirm;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бланкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAddOrder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem архивыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсыДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьАрхивовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыКлиентовToolStripMenuItem;
    }
}

