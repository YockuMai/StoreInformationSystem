namespace RGR
{
    partial class ReferenceSalesPeriod
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
            buttonOk = new Button();
            dataGridView1 = new DataGridView();
            buttonAccept = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            buttonPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.FlatStyle = FlatStyle.System;
            buttonOk.Location = new Point(278, 299);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(94, 29);
            buttonOk.TabIndex = 2;
            buttonOk.Text = "Закрыть";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
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
            dataGridView1.TabIndex = 3;
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
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(104, 17);
            dateTimePicker1.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(165, 27);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.Value = new DateTime(2024, 4, 26, 12, 1, 14, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(380, 17);
            dateTimePicker2.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePicker2.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(163, 27);
            dateTimePicker2.TabIndex = 7;
            // 
            // label1
            // 
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(86, 40);
            label1.TabIndex = 8;
            label1.Text = "Начальная дата";
            // 
            // label2
            // 
            label2.Location = new Point(293, 9);
            label2.Name = "label2";
            label2.Size = new Size(84, 40);
            label2.TabIndex = 9;
            label2.Text = "Конечная дата";
            // 
            // buttonPrint
            // 
            buttonPrint.FlatStyle = FlatStyle.System;
            buttonPrint.Location = new Point(549, 299);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(94, 29);
            buttonPrint.TabIndex = 10;
            buttonPrint.Text = "Печать";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // ReferenceSalesPeriod
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
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(buttonAccept);
            Controls.Add(dataGridView1);
            Controls.Add(buttonOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReferenceSalesPeriod";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Справка";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOk;
        private DataGridView dataGridView1;
        private Button buttonAccept;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private Button buttonPrint;
    }
}