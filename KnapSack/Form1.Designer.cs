namespace KnapSack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCalculate = new Button();
            cmbData = new ComboBox();
            lbResults = new ListBox();
            txtError = new TextBox();
            lblDataSize = new Label();
            label1 = new Label();
            lblMaxValue = new Label();
            label3 = new Label();
            txtSelectedItems = new TextBox();
            lblTitleResultList = new Label();
            label2 = new Label();
            lblSize = new Label();
            label5 = new Label();
            lblCapacity = new Label();
            SuspendLayout();
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = SystemColors.HotTrack;
            btnCalculate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalculate.ForeColor = SystemColors.ButtonHighlight;
            btnCalculate.Location = new Point(227, 190);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(104, 43);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "Hesapla";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // cmbData
            // 
            cmbData.FormattingEnabled = true;
            cmbData.Location = new Point(227, 43);
            cmbData.Name = "cmbData";
            cmbData.Size = new Size(492, 28);
            cmbData.TabIndex = 1;
            cmbData.SelectedIndexChanged += cmbData_SelectedIndexChanged;
            // 
            // lbResults
            // 
            lbResults.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbResults.FormattingEnabled = true;
            lbResults.ItemHeight = 25;
            lbResults.Location = new Point(767, 110);
            lbResults.Name = "lbResults";
            lbResults.Size = new Size(283, 329);
            lbResults.TabIndex = 2;
            // 
            // txtError
            // 
            txtError.BackColor = SystemColors.InfoText;
            txtError.BorderStyle = BorderStyle.None;
            txtError.Font = new Font("Segoe UI Historic", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            txtError.ForeColor = Color.White;
            txtError.Location = new Point(12, 506);
            txtError.MaximumSize = new Size(1062, 200);
            txtError.MinimumSize = new Size(1000, 60);
            txtError.Multiline = true;
            txtError.Name = "txtError";
            txtError.ReadOnly = true;
            txtError.ScrollBars = ScrollBars.Both;
            txtError.Size = new Size(1038, 100);
            txtError.TabIndex = 3;
            txtError.Text = "Hata Olursa Yazılacak";
            txtError.TextAlign = HorizontalAlignment.Center;
            txtError.Visible = false;
            txtError.TextChanged += txtError_TextChanged;
            // 
            // lblDataSize
            // 
            lblDataSize.FlatStyle = FlatStyle.System;
            lblDataSize.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblDataSize.ForeColor = SystemColors.MenuText;
            lblDataSize.Location = new Point(12, 43);
            lblDataSize.Name = "lblDataSize";
            lblDataSize.RightToLeft = RightToLeft.No;
            lblDataSize.Size = new Size(200, 25);
            lblDataSize.TabIndex = 4;
            lblDataSize.Text = "Veri Dosyası :";
            lblDataSize.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuText;
            label1.Location = new Point(12, 253);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(200, 25);
            label1.TabIndex = 5;
            label1.Text = "Maksimum Değer:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMaxValue
            // 
            lblMaxValue.AutoSize = true;
            lblMaxValue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMaxValue.Location = new Point(252, 253);
            lblMaxValue.Name = "lblMaxValue";
            lblMaxValue.Size = new Size(0, 25);
            lblMaxValue.TabIndex = 6;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.MenuText;
            label3.Location = new Point(12, 305);
            label3.Name = "label3";
            label3.Size = new Size(200, 50);
            label3.TabIndex = 7;
            label3.Text = "Çözüme Dahil Edilen İtemler :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSelectedItems
            // 
            txtSelectedItems.BorderStyle = BorderStyle.None;
            txtSelectedItems.Enabled = false;
            txtSelectedItems.Location = new Point(227, 305);
            txtSelectedItems.Multiline = true;
            txtSelectedItems.Name = "txtSelectedItems";
            txtSelectedItems.ReadOnly = true;
            txtSelectedItems.Size = new Size(492, 134);
            txtSelectedItems.TabIndex = 8;
            // 
            // lblTitleResultList
            // 
            lblTitleResultList.AutoSize = true;
            lblTitleResultList.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitleResultList.Location = new Point(804, 43);
            lblTitleResultList.Name = "lblTitleResultList";
            lblTitleResultList.Size = new Size(195, 20);
            lblTitleResultList.TabIndex = 9;
            lblTitleResultList.Text = "En iyi 5 optimal sonuç";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(99, 103);
            label2.Name = "label2";
            label2.Size = new Size(113, 22);
            label2.TabIndex = 10;
            label2.Text = "Veri Boyutu :";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblSize.ForeColor = SystemColors.InfoText;
            lblSize.Location = new Point(227, 103);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(0, 22);
            lblSize.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.InfoText;
            label5.Location = new Point(122, 145);
            label5.Name = "label5";
            label5.Size = new Size(90, 22);
            label5.TabIndex = 12;
            label5.Text = "Kapasite :";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblCapacity.ForeColor = SystemColors.InfoText;
            lblCapacity.Location = new Point(227, 145);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(0, 22);
            lblCapacity.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1062, 618);
            Controls.Add(lblCapacity);
            Controls.Add(label5);
            Controls.Add(lblSize);
            Controls.Add(label2);
            Controls.Add(lblTitleResultList);
            Controls.Add(txtSelectedItems);
            Controls.Add(label3);
            Controls.Add(lblMaxValue);
            Controls.Add(label1);
            Controls.Add(lblDataSize);
            Controls.Add(txtError);
            Controls.Add(lbResults);
            Controls.Add(cmbData);
            Controls.Add(btnCalculate);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KnapSack Solver";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalculate;
        private ComboBox cmbData;
        private ListBox lbResults;
        private TextBox txtError;
        private Label lblDataSize;
        private Label label1;
        private Label lblMaxValue;
        private Label label3;
        private TextBox txtSelectedItems;
        private Label lblTitleResultList;
        private Label label2;
        private Label lblSize;
        private Label label5;
        private Label lblCapacity;
    }
}