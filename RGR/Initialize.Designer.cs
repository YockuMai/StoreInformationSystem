namespace RGR
{
    partial class Initialize
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.GradientInactiveCaption;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(121, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.GradientInactiveCaption;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(121, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.GradientInactiveCaption;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(121, 78);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.GradientInactiveCaption;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(121, 111);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.GradientInactiveCaption;
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(121, 144);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 15);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 5;
            label1.Text = "Ip";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 48);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 6;
            label2.Text = "Порт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 81);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 7;
            label3.Text = "Логин";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 114);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 8;
            label4.Text = "Пароль";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 147);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 9;
            label5.Text = "Название БД";
            // 
            // buttonOK
            // 
            buttonOK.BackColor = SystemColors.ActiveCaption;
            buttonOK.FlatStyle = FlatStyle.System;
            buttonOK.Location = new Point(54, 188);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(94, 29);
            buttonOK.TabIndex = 10;
            buttonOK.Text = "Ок";
            buttonOK.UseVisualStyleBackColor = false;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = SystemColors.ActiveCaption;
            buttonCancel.FlatStyle = FlatStyle.System;
            buttonCancel.Location = new Point(166, 188);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // Initialize
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            CancelButton = buttonCancel;
            ClientSize = new Size(312, 229);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Initialize";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ввод данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonOK;
        private Button buttonCancel;
    }
}