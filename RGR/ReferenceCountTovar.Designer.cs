namespace RGR
{
    partial class ReferenceCountTovar
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
            buttonPrint = new Button();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            buttonAccept = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.FlatStyle = FlatStyle.System;
            buttonOk.Location = new Point(278, 299);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(94, 29);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "Закрыть";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonPrint
            // 
            buttonPrint.FlatStyle = FlatStyle.System;
            buttonPrint.Location = new Point(549, 299);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(94, 29);
            buttonPrint.TabIndex = 11;
            buttonPrint.Text = "Печать";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
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
            dataGridView1.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.GradientInactiveCaption;
            comboBox1.FlatStyle = FlatStyle.System;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Location = new Point(340, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 13;
            // 
            // buttonAccept
            // 
            buttonAccept.BackColor = SystemColors.ActiveCaption;
            buttonAccept.FlatStyle = FlatStyle.System;
            buttonAccept.Location = new Point(549, 18);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(100, 29);
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Применить";
            buttonAccept.UseVisualStyleBackColor = false;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 22);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 15;
            label1.Text = "Товар:";
            // 
            // ReferenceCountTovar
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            CancelButton = buttonOk;
            ClientSize = new Size(661, 340);
            Controls.Add(label1);
            Controls.Add(buttonAccept);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(buttonPrint);
            Controls.Add(buttonOk);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReferenceCountTovar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Справка";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOk;
        private Button buttonPrint;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Button buttonAccept;
        private Label label1;
    }
}