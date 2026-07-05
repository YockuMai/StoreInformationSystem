namespace RGR
{
    partial class ReferenceSalesMY
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
            dataGridView1 = new DataGridView();
            buttonOk = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            buttonAccept = new Button();
            label1 = new Label();
            label2 = new Label();
            buttonPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(637, 241);
            dataGridView1.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.FlatStyle = FlatStyle.System;
            buttonOk.Location = new Point(278, 299);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(94, 29);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "Закрыть";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.GradientInactiveCaption;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Location = new Point(98, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = SystemColors.GradientInactiveCaption;
            comboBox2.FormattingEnabled = true;
            comboBox2.IntegralHeight = false;
            comboBox2.Location = new Point(340, 18);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 3;
            // 
            // buttonAccept
            // 
            buttonAccept.FlatStyle = FlatStyle.System;
            buttonAccept.Location = new Point(549, 18);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(100, 29);
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Применить";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 22);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 5;
            label1.Text = "Месяц";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(301, 22);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 6;
            label2.Text = "Год";
            // 
            // buttonPrint
            // 
            buttonPrint.FlatStyle = FlatStyle.System;
            buttonPrint.Location = new Point(549, 299);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(94, 29);
            buttonPrint.TabIndex = 9;
            buttonPrint.Text = "Печать";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // ReferenceSalesMY
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            CancelButton = buttonOk;
            ClientSize = new Size(661, 340);
            Controls.Add(buttonPrint);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAccept);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(buttonOk);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReferenceSalesMY";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Справка";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonOk;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button buttonAccept;
        private Label label1;
        private Label label2;
        private Button buttonPrint;
    }
}