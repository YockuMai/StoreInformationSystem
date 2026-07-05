using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RGR
{
    public partial class ReferenceSalesOtdel : Form
    {
        MainForm mainForm;
        public ReferenceSalesOtdel()
        {
            InitializeComponent();
            mainForm = null;
        }
        public ReferenceSalesOtdel(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            addDataComboBox();
        }

        private void addDataComboBox()
        {
            string comand = "SELECT * FROM Отделы ORDER BY ИдентификаторОтдела;";
            DataTable dt = new DataTable();
            dt = mainForm.GetData(comand);
            dt.Columns.Add("НазваниеНомер", typeof(string), "Название + '(' + НомерОтдела + ')'");
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "НазваниеНомер";
            comboBox1.ValueMember = dt.Columns[0].ColumnName;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                dataGridView1.DataSource = null;
                string comand = "SELECT * FROM Справка_о_продажах_в_отделе(" + comboBox1.SelectedValue.ToString() + ");";
                DataTable dt = new DataTable();
                dt = mainForm.GetData(comand);
                dataGridView1.DataSource = dt;
            }

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DataRowView rowView = (DataRowView)comboBox1.SelectedItem;
            DataGridViewPrinter printer = new DataGridViewPrinter(dataGridView1, rowView.Row[1].ToString());

            // Печать DataGridView
            if (!printer.Print())
            {
                MessageBox.Show("Ошибка при печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class DataGridViewPrinter
        {
            private string selTable;
            private DataGridView dataGridView;
            private PrintDocument printDocument;
            private int pageWidth, pageHeight;
            private int rowIndex = 0;
            private int rowsPerPage;
            private int pageCount = 1;

            public DataGridViewPrinter(DataGridView dataGridView, string selTable)
            {
                this.dataGridView = dataGridView;

                // Создание объекта PrintDocument
                printDocument = new PrintDocument();
                printDocument.PrintPage += new PrintPageEventHandler(PrintPage);

                // Определение размера страницы
                pageWidth = printDocument.DefaultPageSettings.PaperSize.Width;
                pageHeight = printDocument.DefaultPageSettings.PaperSize.Height;

                // Рассчитываем количество строк на странице
                rowsPerPage = pageHeight / dataGridView.RowTemplate.Height;
                this.selTable = selTable;
            }

            public bool Print()
            {
                // Отображение диалогового окна печати
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                DialogResult result = printDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Начало процесса печати
                    printDocument.Print();
                    return true;
                }
                else if (result == DialogResult.Cancel)
                    return true;
                else
                { return false; }
            }

            private void PrintPage(object sender, PrintPageEventArgs e)
            {
                // Начало печати
                Graphics g = e.Graphics;
                g.TranslateTransform(50, 50); // Смещение для отступов

                // Печать заголовка
                string header = "Справка о продажах в отделе " + selTable;
                Font headerFont = new Font("Arial", 16, FontStyle.Bold);
                g.DrawString(header, headerFont, Brushes.Black, new PointF(0, 0));

                // Печать названий столбцов
                int startY = (int)g.MeasureString(header, headerFont).Height + 10; // Начальная позиция для печати содержимого
                int cellHeight = dataGridView.RowTemplate.Height;

                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    string columnHeader = dataGridView.Columns[j].HeaderText;
                    g.DrawString(columnHeader, dataGridView.Font, Brushes.Black, new RectangleF(j * 100, startY, dataGridView.Columns[j].Width, cellHeight));
                }

                startY += cellHeight;

                // Печать содержимого DataGridView
                int currentRow = rowIndex;

                for (int i = 0; i < rowsPerPage; i++)
                {
                    if (currentRow < dataGridView.Rows.Count)
                    {
                        // Печать строки DataGridView
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            string cellValue = dataGridView.Rows[currentRow].Cells[j].FormattedValue.ToString();
                            g.DrawString(cellValue, dataGridView.Font, Brushes.Black, new RectangleF(j * 100, startY + i * cellHeight, dataGridView.Columns[j].Width, cellHeight));
                        }
                        currentRow++;
                    }
                    else
                    {
                        // Если достигнут конец таблицы, завершаем печать
                        rowIndex = 0;
                        e.HasMorePages = false;
                        return;
                    }
                }

                // Увеличиваем номер строки для следующей страницы
                rowIndex = currentRow;

                // Печать номера страницы
                string pageCountStr = "Page " + pageCount++;
                Font pageFont = new Font("Arial", 10);
                g.DrawString(pageCountStr, pageFont, Brushes.Black, new PointF(pageWidth - g.MeasureString(pageCountStr, pageFont).Width, pageHeight - g.MeasureString(pageCountStr, pageFont).Height));

                // Указываем, что есть еще страницы для печати
                e.HasMorePages = true;
            }

        }
    }
 
}
