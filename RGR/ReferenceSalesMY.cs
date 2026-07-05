using System.Data;
using System.Drawing.Printing;
using System.Globalization;

namespace RGR
{
    public partial class ReferenceSalesMY : Form
    {
        MainForm mainForm;
        public ReferenceSalesMY()
        {
            InitializeComponent();
            addDataComboBox();
        }

        public ReferenceSalesMY(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            addDataComboBox();
        }

        private void addDataComboBox()
        {
            List<string> items1 = new List<string>();
            items1.Add("-");
            for (int i = 1; i < 13; i++)
            {
                items1.Add(i.ToString());
            }
            comboBox1.DataSource = items1;
            List<string> items2 = new List<string>();
            for (int i = 2000; i <= 2050; i++)
            {
                items2.Add(i.ToString());
            }
            comboBox2.DataSource = items2;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                dataGridView1.DataSource = null;
                if (comboBox1.SelectedItem.ToString() == "-")
                {
                    string comand = "SELECT * FROM Справка_о_продажах_за_год('01.01." + comboBox2.SelectedItem.ToString() + "');";
                    DataTable dt = new DataTable();
                    dt = mainForm.GetData(comand);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    string comand = "SELECT * FROM Справка_о_продажах_за_месяц('01." + comboBox1.SelectedItem.ToString() + "." + comboBox2.SelectedItem.ToString() + "');";
                    DataTable dt = new DataTable();
                    dt = mainForm.GetData(comand);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //DataRowView rowView1 = (DataRowView)comboBox1.SelectedItem;
            //DataRowView rowView2 = (DataRowView)comboBox2.SelectedItem;
            CultureInfo culture = new CultureInfo("ru-RU");

            // Получаем объект DateTimeFormatInfo для текущего культурного языка
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string monthName;
            // Получаем название месяца
            if (comboBox1.SelectedItem.ToString() != "-")
                monthName = dtfi.GetMonthName(int.Parse(comboBox1.SelectedItem.ToString()));
            else
                monthName = "-";

            DataGridViewPrinter printer = new DataGridViewPrinter(dataGridView1, monthName, comboBox2.SelectedItem.ToString());

            // Печать DataGridView
            if (!printer.Print())
            {
                MessageBox.Show("Ошибка при печати", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class DataGridViewPrinter
        {
            private string month;
            private string year;
            private DataGridView dataGridView;
            private PrintDocument printDocument;
            private int pageWidth, pageHeight;
            private int rowIndex = 0;
            private int rowsPerPage;
            private int pageCount = 1;

            public DataGridViewPrinter(DataGridView dataGridView, string month, string year)
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
                this.month = month;
                this.year = year;
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
                string header = "Справка о продажах за ";
                if (month == "-")
                {
                    header += year +" год";
                }
                else
                {
                    header += month + " " + year + " года";
                }
                
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
