using Npgsql;
using System.Data;
using System.Diagnostics;

namespace RGR
{
    public partial class MainForm : Form
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;
        private NpgsqlDataAdapter dataAdapter;
        private string selTable = "";
        private string selDB = "";
        private List<int> deletingRow = new List<int>();
        private bool isChanged = false;
        private string Ip = "";
        private string Port = "";
        private string UName = "";
        private string NDB = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize initialize = new Initialize();
            if (initialize.ShowDialog() == DialogResult.OK)
            {
                Ip = initialize.getIp();
                Port = initialize.getPort();
                UName = initialize.getLogin();
                NDB = initialize.getNameDB();
                string host_connect = "Server=" + initialize.getIp() + ";Port=" + initialize.getPort() + ";Username=" + initialize.getLogin() + ";Password=" + initialize.getPassword() + ";Database=" + initialize.getNameDB() + ";Pooling=false;";
                try
                {
                    conn = new NpgsqlConnection(host_connect);
                    conn.Open();
                    selDB = initialize.getNameDB();
                }
                catch (Exception)
                {
                    labelSost.Text = "Состояние: Ошибка";
                    if (conn != null && conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                    return;
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    labelSost.Text = "Состояние: Подключено";
                    подключитьсяToolStripMenuItem.Enabled = false;
                    отключитьсяToolStripMenuItem.Enabled = true;
                    работаСТаблицамиToolStripMenuItem.Enabled = true;
                    работаСБДToolStripMenuItem.Enabled = true;
                    справкиToolStripMenuItem.Enabled = true;

                    updateTree();
                }
            }
        }

        private void updateTree()
        {
            treeView1.Nodes.Clear();
            DataSet dataSet = new DataSet();
            cmd = new NpgsqlCommand("SELECT datname From pg_database WHERE datistemplate=false;", conn);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
            adapter.Fill(dataSet, "database");
            foreach (DataRow row in dataSet.Tables["database"].Rows)
            {
                // Создаем новый узел для каждой базы данных
                if (row["datname"].ToString() == selDB)
                {
                    TreeNode databaseNode = new TreeNode(row["datname"].ToString());

                    // Получаем название базы данных
                    string databaseName = row["datname"].ToString();

                    // Добавляем узел базы данных к корневому узлу дерева
                    treeView1.Nodes.Add(databaseNode);

                    // Запрос для получения списка таблиц в текущей базе данных
                    string query = $"SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' AND table_catalog = '{databaseName}';";

                    // Выполняем запрос и получаем результат
                    cmd = new NpgsqlCommand(query, conn);
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    // Добавляем узлы таблиц к узлу текущей базы данных
                    while (reader.Read())
                    {
                        string tableName = reader.GetString(0); // Получаем название таблицы
                        TreeNode tableNode = new TreeNode(tableName);
                        databaseNode.Nodes.Add(tableNode); // Добавляем узел таблицы к узлу базы данных
                    }

                    // Закрываем reader
                    reader.Close();
                    databaseNode.Expand();
                }
            }
        }

        private void отключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
            else
                return;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                labelSost.Text = "Состояние: Отключено";
                подключитьсяToolStripMenuItem.Enabled = true;
                отключитьсяToolStripMenuItem.Enabled = false;
                работаСТаблицамиToolStripMenuItem.Enabled = false;
                работаСБДToolStripMenuItem.Enabled = false;
                справкиToolStripMenuItem.Enabled = false;

                treeView1.Nodes.Clear();
                dataGridView1.DataSource = null;
                selTable = "";
                selDB = "";
                labelTable.Text = "Текущая таблица: ";

                Ip = "";
                Port = "";
                UName = "";
                NDB = "";
            }
        }

        //private bool IsDataGridViewChanged()
        //{
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        // Проверяем, является ли строка измененной или добавленной
        //        if (row.Index != dataGridView1.NewRowIndex && row.DataBoundItem != null)
        //        {
        //            var rowView = (DataRowView)row.DataBoundItem;
        //            var rowState = rowView.Row.RowState;

        //            if (rowState == DataRowState.Modified || rowState == DataRowState.Added)
        //            {
        //                return true;
        //            }
        //        }
        //        else if (row.Index != dataGridView1.NewRowIndex)
        //        {
        //            // Строка удалена пользователем
        //            return true;
        //        }
        //    }
        //    return false;

        //}

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (isChanged)
            {
                ChangeRows changeRows = new ChangeRows();
                DialogResult result = changeRows.ShowDialog();
                if (result == DialogResult.OK)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.No)
                { isChanged = false; }
            }
            TreeNode clickedNode = e.Node;


            if (clickedNode.Level == 1)
            {
                selTable = clickedNode.Text;
                labelTable.Text = "Текущая таблица: " + selTable;
                updateTable();
                dataGridView1.Columns[0].ReadOnly = true;
            }
        }

        // Просмотр таблицы в "красивом" виде
        private void просмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selTable != "")
            {
                if (isChanged)
                {
                    ChangeRows changeRows = new ChangeRows();
                    DialogResult result = changeRows.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        сохранитьToolStripMenuItem_Click(sender, e);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.No)
                    { isChanged = false; }
                }
                string comand = "";
                if (selTable == "Отделы")
                {
                    comand = "SELECT ИдентификаторОтдела AS Идентификатор, Название AS Название, НомерОтдела AS Номер, Заведующий FROM " + selTable + " ORDER BY 1 ASC";
                }
                if (selTable == "Сотрудники")
                {
                    comand = "SELECT ИдентификаторСотрудника AS Идентификатор, Имя, Фамилия, НомерСотрудника AS Номер, ДатаПоступленияНаРаботу AS Дата_найма, Отделы.Название AS Отдел, Должность, Специализация FROM " + selTable + " JOIN Отделы ON Отделы.ИдентификаторОтдела=Сотрудники.ИдОтдела" + " ORDER BY 1 ASC";
                }
                if (selTable == "Продажи")
                {
                    comand = "SELECT ИдентификаторПродажи AS Идентификатор, Товары.Название AS Товар, Отделы.Название AS Отдел, ДатаПродажи AS Дата_продажи, Сотрудники.Фамилия AS Продавец FROM " + selTable + " JOIN Отделы ON Отделы.ИдентификаторОтдела=Продажи.ИдОтдела JOIN Товары ON Товары.ИдентификаторТовара=Продажи.ИдТовара JOIN Сотрудники ON Сотрудники.ИдентификаторСотрудника=Продажи.ИдПродавца" + " ORDER BY 1 ASC";
                }
                if (selTable == "Товары")
                {
                    comand = "SELECT ИдентификаторТовара AS Идентификатор, Товары.Название, НомерТовара AS Номер, Отделы.Название AS Отдел, Стоимость, Количество FROM " + selTable + " JOIN Отделы ON Отделы.ИдентификаторОтдела=Товары.ИдОтдела" + " ORDER BY 1 ASC";
                }
                cmd = new NpgsqlCommand(comand, conn);
                dataAdapter = new NpgsqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, selTable);
                dataGridView1.DataSource = dataSet.Tables[selTable];
                dataGridView1.ReadOnly = true;
            }
        }

        private void updateTable()
        {
            dataGridView1.ReadOnly = false;
            // Очистить текущий DataSource
            dataGridView1.DataSource = null;

            // Загрузить новые данные
            string comand = "SELECT * FROM " + selTable + " ORDER BY 1 ASC";
            cmd = new NpgsqlCommand(comand, conn);
            dataAdapter = new NpgsqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, selTable);

            // Установить новый DataSource
            dataGridView1.DataSource = dataSet.Tables[selTable];

        }

        // Сохранение таблицы в БД
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count - 1; rowIndex++) // Исключаем последнюю пустую строку
                {
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];
                    //bool все_ячейки_заполнены = true;
                    for (int i = 1; i < row.Cells.Count; i++) // Начинаем с индекса 1, чтобы пропустить первую ячейку
                    {
                        if (row.Cells[i].Value == null || string.IsNullOrEmpty(row.Cells[i].Value.ToString()))
                        {
                            //все_ячейки_заполнены = false;
                            // Вывести диалог с сообщением об ошибке
                            MessageBox.Show("Все ячейки строк должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                try
                {
                    if (selTable == "Продажи")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow && row.DataBoundItem != null)
                            {
                                var rowView = (DataRowView)row.DataBoundItem;
                                int rowIndexInGrid = row.Index;

                                if (dataGridView1.Rows.Contains(row)) // Проверяем, содержится ли строка в DataGridView
                                {
                                    var rowState = rowView.Row.RowState;

                                    if (rowState == DataRowState.Added)
                                    {
                                        string comand = "SELECT ДобавитьПродажи(" + row.Cells[1].Value.ToString() + "," + row.Cells[2].Value.ToString() + ",'" + row.Cells[3].Value.ToString() + "'," + row.Cells[4].Value.ToString() + ");";
                                        //try
                                        //{
                                        cmd = new NpgsqlCommand(comand, conn);
                                        reader = cmd.ExecuteReader();
                                        //}
                                        //catch (Npgsql.PostgresException)
                                        //{
                                        //    MessageBox.Show("Неверный(-ые) идентификаторы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //}
                                        // Здесь вы можете использовать полученные значения
                                        if (reader != null)
                                            reader.Close();
                                    }
                                    else if (rowState == DataRowState.Modified)
                                    {
                                        // Код для изменения существующей записи
                                        //string comand = "UPDATE " + selTable + " SET ИдТовара=" + row.Cells[1].Value.ToString() + ",ИдОтдела=" + row.Cells[2].Value.ToString() + ",ДатаПродажи='" + row.Cells[3].Value.ToString() + "',ИдПродавца=" + row.Cells[4].Value.ToString() + ");" + " WHERE ИдентификаторПродажи=" + row.Cells[0].Value.ToString();
                                        string comand = "SELECT Обновление_Продаж(" + row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() + "," + row.Cells[2].Value.ToString() + ",'" + row.Cells[3].Value.ToString() + "'," + row.Cells[4].Value.ToString() + ");";
                                        try
                                        {
                                            cmd = new NpgsqlCommand(comand, conn);
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Npgsql.PostgresException)
                                        {
                                            MessageBox.Show("Неверный(-ые) идентификаторы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        // Код для обработки существующих записей
                                        //labelTable.Text = "Да";
                                    }
                                }

                            }
                        }
                    }
                    if (selTable == "Сотрудники")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow && row.DataBoundItem != null)
                            {
                                var rowView = (DataRowView)row.DataBoundItem;
                                int rowIndexInGrid = row.Index;

                                if (dataGridView1.Rows.Contains(row)) // Проверяем, содержится ли строка в DataGridView
                                {
                                    var rowState = rowView.Row.RowState;

                                    if (rowState == DataRowState.Added)
                                    {
                                        string checkDepartmentCommand = "SELECT COUNT(*) FROM Отделы WHERE ИдентификаторОтдела = " + row.Cells[5].Value.ToString();
                                        cmd = new NpgsqlCommand(checkDepartmentCommand, conn);
                                        int departmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Если отдел существует, выполнить вставку
                                        if (departmentCount > 0)
                                        {
                                            string comand = "SELECT ДобавитьСотрудника('" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'," + row.Cells[3].Value.ToString() + ",'" + row.Cells[4].Value.ToString() + "'," + row.Cells[5].Value.ToString() + ",'" + row.Cells[6].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "');";
                                            try
                                            {
                                                cmd = new NpgsqlCommand(comand, conn);
                                                reader = cmd.ExecuteReader();
                                            }
                                            catch (Npgsql.PostgresException)
                                            {
                                                MessageBox.Show("Ошибка при добавлении сотрудника " + row.Cells[2].Value.ToString() + "!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Неверный идентификатор отдела!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        // Здесь вы можете использовать полученные значения
                                        if (reader != null)
                                            reader.Close();
                                    }
                                    else if (rowState == DataRowState.Modified)
                                    {
                                        // Код для изменения существующей записи
                                        //string comand = "UPDATE " + selTable + " SET Имя='" + row.Cells[1].Value.ToString() + "',Фамилия='" + row.Cells[2].Value.ToString() + "',НомерСотрудника=" + row.Cells[3].Value.ToString() + ",ДатаПоступленияНаРаботу='" + row.Cells[4].Value.ToString() + "',ИдОтдела=" + row.Cells[5].Value.ToString() + ",Должность='" + row.Cells[6].Value.ToString() + "',Специализация='" + row.Cells[7].Value.ToString() + "' WHERE ИдентификаторСотрудника=" + row.Cells[0].Value.ToString() + ";";
                                        string comand = "SELECT Обновление_Сотрудников(" + row.Cells[0].Value.ToString() + ",'" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "'," + row.Cells[3].Value.ToString() + ",'" + row.Cells[4].Value.ToString() + "'," + row.Cells[5].Value.ToString() + ",'" + row.Cells[6].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "');";
                                        try
                                        {
                                            cmd = new NpgsqlCommand(comand, conn);
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Npgsql.PostgresException)
                                        {
                                            MessageBox.Show("Неверный идентификатор отдела!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        // Код для обработки существующих записей
                                        //labelTable.Text = "Да";
                                    }
                                }

                            }
                        }
                    }
                    if (selTable == "Отделы")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow && row.DataBoundItem != null)
                            {
                                var rowView = (DataRowView)row.DataBoundItem;
                                int rowIndexInGrid = row.Index;

                                if (dataGridView1.Rows.Contains(row)) // Проверяем, содержится ли строка в DataGridView
                                {
                                    var rowState = rowView.Row.RowState;

                                    if (rowState == DataRowState.Added)
                                    {
                                        string comand = "SELECT ДобавитьОтдел(" + "'" + row.Cells[1].Value.ToString() + "'," + row.Cells[2].Value.ToString() + ",'" + row.Cells[3].Value.ToString() + "');";
                                        cmd = new NpgsqlCommand(comand, conn);
                                        reader = cmd.ExecuteReader();
                                        // Здесь вы можете использовать полученные значения

                                        reader.Close();
                                    }
                                    else if (rowState == DataRowState.Modified)
                                    {
                                        // Код для изменения существующей записи
                                        //string comand = "UPDATE " + selTable + " SET Название=" + "'" + row.Cells[1].Value.ToString() + "', НомерОтдела=" + row.Cells[2].Value.ToString() + ", Заведующий='" + row.Cells[3].Value.ToString() + "' WHERE ИдентификаторОтдела=" + row.Cells[0].Value.ToString();
                                        string comand = "SELECT Обновление_Отделов(" + row.Cells[0].Value.ToString() + ",'" + row.Cells[1].Value.ToString() + "'," + row.Cells[2].Value.ToString() + ",'" + row.Cells[3].Value.ToString() + "');";
                                        cmd = new NpgsqlCommand(comand, conn);
                                        cmd.ExecuteNonQuery();

                                    }
                                    else
                                    {
                                        // Код для обработки существующих записей
                                        //labelTable.Text = "Да";
                                    }
                                }

                            }
                        }
                    }
                    if (selTable == "Товары")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow && row.DataBoundItem != null)
                            {
                                var rowView = (DataRowView)row.DataBoundItem;
                                int rowIndexInGrid = row.Index;

                                if (dataGridView1.Rows.Contains(row)) // Проверяем, содержится ли строка в DataGridView
                                {
                                    var rowState = rowView.Row.RowState;

                                    if (rowState == DataRowState.Added)
                                    {
                                        string checkDepartmentCommand = "SELECT COUNT(*) FROM Отделы WHERE ИдентификаторОтдела = " + row.Cells[3].Value.ToString();
                                        cmd = new NpgsqlCommand(checkDepartmentCommand, conn);
                                        int departmentCount = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Если отдел существует, выполнить вставку
                                        if (departmentCount > 0)
                                        {
                                            string comand = "SELECT ДобавитьТовар('" + row.Cells[1].Value.ToString() + "'," + row.Cells[2].Value.ToString() + "," + row.Cells[3].Value.ToString() + "," + row.Cells[4].Value.ToString().Replace(',', '.') + "," + row.Cells[5].Value.ToString() + ");";
                                            try
                                            {
                                                cmd = new NpgsqlCommand(comand, conn);
                                                reader = cmd.ExecuteReader();
                                            }
                                            catch (Npgsql.PostgresException)
                                            {
                                                MessageBox.Show("Ошибка при добавлении товара " + row.Cells[1].Value.ToString() + "!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Неверный идентификатор отдела!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        // Здесь вы можете использовать полученные значения
                                        if (reader != null)
                                            reader.Close();
                                    }
                                    else if (rowState == DataRowState.Modified)
                                    {
                                        // Код для изменения существующей записи
                                        //string comand = "UPDATE " + selTable + " SET Название='" + row.Cells[1].Value.ToString() + "',НомерТовара=" + row.Cells[2].Value.ToString() + ",ИдОтдела=" + row.Cells[3].Value.ToString() + ",Стоимость=" + row.Cells[4].Value.ToString() + ",Количество=" + row.Cells[5].Value.ToString() + " WHERE ИдентификаторТовара=" + row.Cells[0].Value.ToString();
                                        string comand = "SELECT Обновление_Товаров(" + row.Cells[0].Value.ToString() + ",'" + row.Cells[1].Value.ToString() + "'," + row.Cells[2].Value.ToString() + "," + row.Cells[3].Value.ToString() + "," + row.Cells[4].Value.ToString().Replace(',', '.') + "," + row.Cells[5].Value.ToString() + ");";
                                        try
                                        {
                                            cmd = new NpgsqlCommand(comand, conn);
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Npgsql.PostgresException)
                                        {
                                            MessageBox.Show("Неверный идентификатор отдела!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        // Код для обработки существующих записей
                                        //labelTable.Text = "Да";
                                    }
                                }

                            }
                        }
                    }
                    if (deletingRow.Count != 0)
                    {
                        for (int i = 0; i < deletingRow.Count; i++)
                        {
                            //string comand = "DELETE FROM " + selTable + " WHERE ИдентификаторОтдела=" + deletingRow[i];
                            string comand = "SELECT Удаление('" + selTable + "'," + deletingRow[i] + ");";
                            cmd = new NpgsqlCommand(comand, conn);
                            cmd.ExecuteNonQuery();
                        }
                        //labelTable.Text = "Да";
                        deletingRow.Clear();
                    }
                }
                catch (Npgsql.PostgresException ex)
                {
                    MessageBox.Show("Ошибка базы данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    updateTable();
                    isChanged = false;
                }
            }
        }

        // Загрузка бд
        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                filePath = openFileDialog1.FileName;

            if (filePath != "")
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files\\PostgreSQL\\16\\bin\\pg_restore.exe";
                psi.Arguments = $"-U {UName} -h {Ip} -p {Port} --dbname={NDB} --clean --if-exists \"{filePath}\"";

                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;

                Process process = new Process();
                process.StartInfo = psi;
                process.Start();

                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("База данных успешно восстановлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка восстановления базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                process.Dispose();
                this.Focus();
                updateTree();
                updateTable();
            }
        }

        // Сохранение бд
        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получение выбранного пути файла
                string filePath = folderBrowserDialog1.SelectedPath;
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files\\PostgreSQL\\16\\bin\\pg_dump.exe";
                psi.Arguments = $"-U {UName} -h {Ip} -p {Port} -F c -f \"{filePath}\\dump.backup\" {NDB}";


                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;

                Process process = new Process();
                process.StartInfo = psi;
                process.Start();

                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show("Успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                process.Dispose();
                this.Focus();
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow && row.DataBoundItem != null && row.Cells[0].Value != DBNull.Value)
                {
                    var rowView = (DataRowView)row.DataBoundItem;

                    deletingRow.Add((int)row.Cells[0].Value);
                }
            }
            isChanged = true;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            isChanged = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isChanged = true;
        }

        public DataTable GetData(string comand)
        {
            cmd = new NpgsqlCommand(comand, conn);
            dataAdapter = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        private void справкаОПродажахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceSalesMY reference = new ReferenceSalesMY(this);
            reference.ShowDialog();
        }

        private void справкаОПродажахВОтделеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceSalesOtdel reference = new ReferenceSalesOtdel(this);
            reference.ShowDialog();
        }

        private void справкаОПродажТовараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceSalesTovar reference = new ReferenceSalesTovar(this);
            reference.ShowDialog();
        }

        private void справкаОПродажахПродавцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceSalesProdavec reference = new ReferenceSalesProdavec(this);
            reference.ShowDialog();
        }

        private void справкаОПродажахЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceSalesPeriod reference = new ReferenceSalesPeriod(this);
            reference.ShowDialog();
        }

        private void справкаОПродажахВсехТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceSalesAll reference = new ReferenceSalesAll(this);
            reference.ShowDialog();
        }

        private void справкаОКоличествеТовараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReferenceCountTovar reference = new ReferenceCountTovar(this);
            reference.ShowDialog();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка: " + e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                ChangeRows changeRows = new ChangeRows();
                DialogResult result = changeRows.ShowDialog();
                if (result == DialogResult.OK)
                {
                    сохранитьToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (result == DialogResult.No)
                { isChanged = false; }
            }
        }
    }
}
