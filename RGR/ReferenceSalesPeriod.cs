using System.Data;
using System.Drawing.Printing;
using System.Globalization;

namespace RGR
{
    public partial class ReferenceSalesPeriod : Form
    {
        MainForm mainForm;
        public ReferenceSalesPeriod()
        {
            InitializeComponent();
        }

        public ReferenceSalesPeriod(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value > dateTimePicker1.Value)
            {
                dataGridView1.DataSource = null;
                string comand = "SELECT * FROM Справка_о_продажах_за_период('" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString() + "');";
                DataTable dt = new DataTable();
                dt = mainForm.GetData(comand);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Выбран неверный период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

            DataGridViewPrinter printer = new DataGridViewPrinter(dataGridView1, dateTimePicker1.Value.Date.ToString().Substring(0, dateTimePicker1.Value.Date.ToString().Length - 8), dateTimePicker2.Value.Date.ToString().Substring(0, dateTimePicker2.Value.Date.ToString().Length - 8));

            // Печать DataGridView
            if (!printer.Print())
            {
                MessageBox.Show("Ошибка при печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class DataGridViewPrinter
        {
            private string beg;
            private string end;
            private DataGridView dataGridView;
            private PrintDocument printDocument;
            private int pageWidth, pageHeight;
            private int rowIndex = 0;
            private int rowsPerPage;
            private int pageCount = 1;

            public DataGridViewPrinter(DataGridView dataGridView, string beg, string end)
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
                this.end = end;
                this.beg = beg;
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
                string header = "Справка о продажах за период " + beg + " - " + end;


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
