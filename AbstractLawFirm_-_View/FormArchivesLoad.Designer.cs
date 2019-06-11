namespace AbstractLawFirm___View
{
    partial class FormArchivesLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Archive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Archive,
            this.Blank,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(12, 77);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(344, 400);
            this.dataGridView.TabIndex = 0;
            // 
            // Archive
            // 
            this.Archive.HeaderText = "Архив";
            this.Archive.Name = "Archive";
            // 
            // Blank
            // 
            this.Blank.HeaderText = "Бланк";
            this.Blank.Name = "Blank";
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(19, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(131, 40);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить в Excel";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // FormArchivesLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 489);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormArchivesLoad";
            this.Text = "Загрузка архивов";
            this.Load += new System.EventHandler(this.FormArchivesLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Archive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Blank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button buttonSave;
    }
}