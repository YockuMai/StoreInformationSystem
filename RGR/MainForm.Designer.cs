namespace RGR
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            соединениеToolStripMenuItem = new ToolStripMenuItem();
            подключитьсяToolStripMenuItem = new ToolStripMenuItem();
            отключитьсяToolStripMenuItem = new ToolStripMenuItem();
            работаСТаблицамиToolStripMenuItem = new ToolStripMenuItem();
            просмотрToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            работаСБДToolStripMenuItem = new ToolStripMenuItem();
            загрузитьИзФайлаToolStripMenuItem = new ToolStripMenuItem();
            сохранитьВФайлToolStripMenuItem = new ToolStripMenuItem();
            справкиToolStripMenuItem = new ToolStripMenuItem();
            справкаОПродажахToolStripMenuItem = new ToolStripMenuItem();
            справкаОПродажахВОтделеToolStripMenuItem = new ToolStripMenuItem();
            справкаОПродажТовараToolStripMenuItem = new ToolStripMenuItem();
            справкаОПродажахПродавцаToolStripMenuItem = new ToolStripMenuItem();
            справкаОПродажахЗаПериодToolStripMenuItem = new ToolStripMenuItem();
            справкаОПродажахВсехТоваровToolStripMenuItem = new ToolStripMenuItem();
            справкаОКоличествеТовараToolStripMenuItem = new ToolStripMenuItem();
            labelSost = new Label();
            dataGridView1 = new DataGridView();
            labelTable = new Label();
            treeView1 = new TreeView();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { соединениеToolStripMenuItem, работаСТаблицамиToolStripMenuItem, работаСБДToolStripMenuItem, справкиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // соединениеToolStripMenuItem
            // 
            соединениеToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            соединениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { подключитьсяToolStripMenuItem, отключитьсяToolStripMenuItem });
            соединениеToolStripMenuItem.Name = "соединениеToolStripMenuItem";
            соединениеToolStripMenuItem.Size = new Size(109, 24);
            соединениеToolStripMenuItem.Text = "Соединение";
            // 
            // подключитьсяToolStripMenuItem
            // 
            подключитьсяToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            подключитьсяToolStripMenuItem.Size = new Size(193, 26);
            подключитьсяToolStripMenuItem.Text = "Подключиться";
            подключитьсяToolStripMenuItem.Click += подключитьсяToolStripMenuItem_Click;
            // 
            // отключитьсяToolStripMenuItem
            // 
            отключитьсяToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            отключитьсяToolStripMenuItem.Enabled = false;
            отключитьсяToolStripMenuItem.Name = "отключитьсяToolStripMenuItem";
            отключитьсяToolStripMenuItem.Size = new Size(193, 26);
            отключитьсяToolStripMenuItem.Text = "Отключиться";
            отключитьсяToolStripMenuItem.Click += отключитьсяToolStripMenuItem_Click;
            // 
            // работаСТаблицамиToolStripMenuItem
            // 
            работаСТаблицамиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { просмотрToolStripMenuItem, сохранитьToolStripMenuItem });
            работаСТаблицамиToolStripMenuItem.Enabled = false;
            работаСТаблицамиToolStripMenuItem.Name = "работаСТаблицамиToolStripMenuItem";
            работаСТаблицамиToolStripMenuItem.Size = new Size(163, 24);
            работаСТаблицамиToolStripMenuItem.Text = "Работа с таблицами";
            // 
            // просмотрToolStripMenuItem
            // 
            просмотрToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            просмотрToolStripMenuItem.Size = new Size(166, 26);
            просмотрToolStripMenuItem.Text = "Просмотр";
            просмотрToolStripMenuItem.Click += просмотрToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // работаСБДToolStripMenuItem
            // 
            работаСБДToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { загрузитьИзФайлаToolStripMenuItem, сохранитьВФайлToolStripMenuItem });
            работаСБДToolStripMenuItem.Enabled = false;
            работаСБДToolStripMenuItem.Name = "работаСБДToolStripMenuItem";
            работаСБДToolStripMenuItem.Size = new Size(105, 24);
            работаСБДToolStripMenuItem.Text = "Работа с БД";
            // 
            // загрузитьИзФайлаToolStripMenuItem
            // 
            загрузитьИзФайлаToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
            загрузитьИзФайлаToolStripMenuItem.Size = new Size(227, 26);
            загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
            загрузитьИзФайлаToolStripMenuItem.Click += загрузитьИзФайлаToolStripMenuItem_Click;
            // 
            // сохранитьВФайлToolStripMenuItem
            // 
            сохранитьВФайлToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            сохранитьВФайлToolStripMenuItem.Name = "сохранитьВФайлToolStripMenuItem";
            сохранитьВФайлToolStripMenuItem.Size = new Size(227, 26);
            сохранитьВФайлToolStripMenuItem.Text = "Сохранить в файл";
            сохранитьВФайлToolStripMenuItem.Click += сохранитьВФайлToolStripMenuItem_Click;
            // 
            // справкиToolStripMenuItem
            // 
            справкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { справкаОПродажахToolStripMenuItem, справкаОПродажахВОтделеToolStripMenuItem, справкаОПродажТовараToolStripMenuItem, справкаОПродажахПродавцаToolStripMenuItem, справкаОПродажахЗаПериодToolStripMenuItem, справкаОПродажахВсехТоваровToolStripMenuItem, справкаОКоличествеТовараToolStripMenuItem });
            справкиToolStripMenuItem.Enabled = false;
            справкиToolStripMenuItem.Name = "справкиToolStripMenuItem";
            справкиToolStripMenuItem.Size = new Size(82, 24);
            справкиToolStripMenuItem.Text = "Справки";
            // 
            // справкаОПродажахToolStripMenuItem
            // 
            справкаОПродажахToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОПродажахToolStripMenuItem.Name = "справкаОПродажахToolStripMenuItem";
            справкаОПродажахToolStripMenuItem.Size = new Size(331, 26);
            справкаОПродажахToolStripMenuItem.Text = "Справка о продажах(месяц, год)";
            справкаОПродажахToolStripMenuItem.Click += справкаОПродажахToolStripMenuItem_Click;
            // 
            // справкаОПродажахВОтделеToolStripMenuItem
            // 
            справкаОПродажахВОтделеToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОПродажахВОтделеToolStripMenuItem.Name = "справкаОПродажахВОтделеToolStripMenuItem";
            справкаОПродажахВОтделеToolStripMenuItem.Size = new Size(331, 26);
            справкаОПродажахВОтделеToolStripMenuItem.Text = "Справка о продажах в отделе";
            справкаОПродажахВОтделеToolStripMenuItem.Click += справкаОПродажахВОтделеToolStripMenuItem_Click;
            // 
            // справкаОПродажТовараToolStripMenuItem
            // 
            справкаОПродажТовараToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОПродажТовараToolStripMenuItem.Name = "справкаОПродажТовараToolStripMenuItem";
            справкаОПродажТовараToolStripMenuItem.Size = new Size(331, 26);
            справкаОПродажТовараToolStripMenuItem.Text = "Справка о продажах товара";
            справкаОПродажТовараToolStripMenuItem.Click += справкаОПродажТовараToolStripMenuItem_Click;
            // 
            // справкаОПродажахПродавцаToolStripMenuItem
            // 
            справкаОПродажахПродавцаToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОПродажахПродавцаToolStripMenuItem.Name = "справкаОПродажахПродавцаToolStripMenuItem";
            справкаОПродажахПродавцаToolStripMenuItem.Size = new Size(331, 26);
            справкаОПродажахПродавцаToolStripMenuItem.Text = "Справка о продажах продавца";
            справкаОПродажахПродавцаToolStripMenuItem.Click += справкаОПродажахПродавцаToolStripMenuItem_Click;
            // 
            // справкаОПродажахЗаПериодToolStripMenuItem
            // 
            справкаОПродажахЗаПериодToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОПродажахЗаПериодToolStripMenuItem.Name = "справкаОПродажахЗаПериодToolStripMenuItem";
            справкаОПродажахЗаПериодToolStripMenuItem.Size = new Size(331, 26);
            справкаОПродажахЗаПериодToolStripMenuItem.Text = "Справка о продажах за период";
            справкаОПродажахЗаПериодToolStripMenuItem.Click += справкаОПродажахЗаПериодToolStripMenuItem_Click;
            // 
            // справкаОПродажахВсехТоваровToolStripMenuItem
            // 
            справкаОПродажахВсехТоваровToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОПродажахВсехТоваровToolStripMenuItem.Name = "справкаОПродажахВсехТоваровToolStripMenuItem";
            справкаОПродажахВсехТоваровToolStripMenuItem.Size = new Size(331, 26);
            справкаОПродажахВсехТоваровToolStripMenuItem.Text = "Справка о продажах всех товаров";
            справкаОПродажахВсехТоваровToolStripMenuItem.Click += справкаОПродажахВсехТоваровToolStripMenuItem_Click;
            // 
            // справкаОКоличествеТовараToolStripMenuItem
            // 
            справкаОКоличествеТовараToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            справкаОКоличествеТовараToolStripMenuItem.Name = "справкаОКоличествеТовараToolStripMenuItem";
            справкаОКоличествеТовараToolStripMenuItem.Size = new Size(331, 26);
            справкаОКоличествеТовараToolStripMenuItem.Text = "Справка о количестве товара";
            справкаОКоличествеТовараToolStripMenuItem.Click += справкаОКоличествеТовараToolStripMenuItem_Click;
            // 
            // labelSost
            // 
            labelSost.AutoSize = true;
            labelSost.Location = new Point(620, 38);
            labelSost.Name = "labelSost";
            labelSost.Size = new Size(168, 20);
            labelSost.TabIndex = 1;
            labelSost.Text = "Состояние: Отключено";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(162, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(626, 325);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            // 
            // labelTable
            // 
            labelTable.AutoSize = true;
            labelTable.Location = new Point(162, 38);
            labelTable.Name = "labelTable";
            labelTable.Size = new Size(135, 20);
            labelTable.TabIndex = 3;
            labelTable.Text = "Текущая таблица: ";
            // 
            // treeView1
            // 
            treeView1.BackColor = SystemColors.ActiveCaption;
            treeView1.Location = new Point(12, 61);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(144, 325);
            treeView1.TabIndex = 4;
            treeView1.NodeMouseDoubleClick += treeView1_NodeMouseDoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 392);
            Controls.Add(treeView1);
            Controls.Add(labelTable);
            Controls.Add(dataGridView1);
            Controls.Add(labelSost);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "База данных";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem соединениеToolStripMenuItem;
        private ToolStripMenuItem подключитьсяToolStripMenuItem;
        private ToolStripMenuItem отключитьсяToolStripMenuItem;
        private Label labelSost;
        private DataGridView dataGridView1;
        private Label labelTable;
        private TreeView treeView1;
        private ToolStripMenuItem работаСТаблицамиToolStripMenuItem;
        private ToolStripMenuItem просмотрToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem работаСБДToolStripMenuItem;
        private ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private ToolStripMenuItem сохранитьВФайлToolStripMenuItem;
        private ToolStripMenuItem справкиToolStripMenuItem;
        private ToolStripMenuItem справкаОПродажахToolStripMenuItem;
        private ToolStripMenuItem справкаОПродажахВОтделеToolStripMenuItem;
        private ToolStripMenuItem справкаОПродажТовараToolStripMenuItem;
        private ToolStripMenuItem справкаОПродажахПродавцаToolStripMenuItem;
        private ToolStripMenuItem справкаОПродажахЗаПериодToolStripMenuItem;
        private ToolStripMenuItem справкаОПродажахВсехТоваровToolStripMenuItem;
        private ToolStripMenuItem справкаОКоличествеТовараToolStripMenuItem;
    }
}
