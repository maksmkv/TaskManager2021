
/*// дела по https://docs.dataabstract.com/NET/Tutorials/TodoTutorial/defineschema/ 
// добавление SQLite3 в проект https://www.youtube.com/watch?v=Cdxz2mNr1a8
//https://stackoverflow.com/questions/19479166/sqlite-simple-insert-query/19489736
//https://stackoverflow.com/questions/31981757/how-to-insert-data-into-sqlite-database-using-c-sharp

//https://www.codeproject.com/Questions/708917/How-To-I-Delete-Selected-Rows-From-Datagrid-And-Da удаление строк рабочий вариант

//https://www.csharp-console-examples.com/database/connecting-c-application-to-sqlite-select-insert-update-delete/ UPDATE

//https://coderoad.ru/40379892/%D0%9F%D0%B5%D1%80%D0%B5%D0%B4%D0%B0%D1%87%D0%B0-%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9-%D1%87%D0%B5%D1%80%D0%B5%D0%B7-%D1%84%D0%BE%D1%80%D0%BC%D1%8B-c      передача строк
//https://coderoad.ru/6936089/%D0%9A%D0%B0%D0%BA-%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%BD%D0%BE-%D0%B2%D1%8B%D0%B1%D1%80%D0%B0%D1%82%D1%8C-%D0%BF%D0%B5%D1%80%D0%B2%D1%83%D1%8E-%D1%81%D1%82%D1%80%D0%BE%D0%BA%D1%83-DataGridView   выделить программно 1 строку
//https://www.cyberforum.ru/windows-forms/thread435177.html
*/


using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Media;
using System.Speech.Synthesis;
using System.Timers;
using System.Windows.Forms;


namespace TaskManager
{

    public partial class mainForm : Form
    {

        System.Timers.Timer timer;
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        readonly SpeechSynthesizer speaker = new SpeechSynthesizer();


        public mainForm()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            this.CustomizeDataGridView();

            SQLiteConnection myconnection = new SQLiteConnection("Data Source=c:\\sqlite\\taskdb.db; Version=3");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            //  cmd.CommandText = "Select * from users";
            cmd.CommandText = "Select * from Task";
            //  cmd.CommandText = "Select * from Priorities";

            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                taskDataGridView.DataSource = dt;
            }

            this.taskDataGridView.Sort(this.taskDataGridView.Columns[2], ListSortDirection.Ascending);

            if (ttsONOFF.Checked)
            {
                initTTS();

                speaker.Speak("Данные загружены");
            }
            else
            {
                return;
            }

            btnStop.Enabled = true;


        }

        private void CustomizeDataGridView()
        {
            this.taskDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.taskDataGridView.MultiSelect = false;
            this.taskDataGridView.AutoGenerateColumns = false;

            this.taskDataGridView.ReadOnly = true;
            this.taskDataGridView.RowHeadersVisible = false;
            this.taskDataGridView.AllowUserToAddRows = false;  //убрать пустую строку в конце GridView

            this.taskDataGridView.Columns.Clear();

            var columnId = new DataGridViewTextBoxColumn { DataPropertyName = "id", HeaderText = "id", Width = 100 };
            var columnDone = new DataGridViewTextBoxColumn { DataPropertyName = "Done", HeaderText = "Статус", Width = 50 };
            var columnDoDate = new DataGridViewTextBoxColumn { DataPropertyName = "DoDate", HeaderText = "Начало события" };
            var columnTask = new DataGridViewTextBoxColumn { DataPropertyName = "Task", HeaderText = "Задача", Width = 75 };
            var columnDetails = new DataGridViewTextBoxColumn { DataPropertyName = "Details", HeaderText = "Описание", Width = 250 };


            this.taskDataGridView.Columns.AddRange(new[] { columnId, columnTask, columnDoDate, columnDone, columnDetails });

            this.taskDataGridView.Columns[0].Visible = false;
            this.taskDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            (new AddTaskForm()).Show();
        }

        private void editTask_Click(object sender, EventArgs e)
        {
            if (taskDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Данные не заполнены!");
            }
            else
            {
                string taskText = taskDataGridView.SelectedCells[1].Value.ToString();
                string dateTask = taskDataGridView.SelectedCells[2].Value.ToString();
                string detailTask = taskDataGridView.SelectedCells[4].Value.ToString();
                string dataStringGridView = taskDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                string isCheckedData = taskDataGridView.SelectedCells[3].Value.ToString();

                EditTaskForm EditForm = new EditTaskForm(taskText, dateTask, detailTask, dataStringGridView, isCheckedData);
                EditForm.Show();
            }
        }


        private void deleteTask_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in taskDataGridView.SelectedRows)
            {
                string connection = @"Data Source=c:\\sqlite\\taskdb.db;Version=3";
                SQLiteConnection sqlite_conn = new SQLiteConnection(connection);

                var stringQuery = $"DELETE FROM Task WHERE id='{this.taskDataGridView.SelectedRows[0].Cells[0].Value.ToString()}'";

                // string stringQuery = "DELETE FROM Task WHERE id=" + this.taskDataGridView.SelectedRows[0].Cells[0].Value.ToString() +"";
                sqlite_conn.Open();//Open the SqliteConnection
                var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
                SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
                SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
                SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
                sqlite_conn.Close();
                taskDataGridView.Rows.Remove(row);
            }


            if (ttsONOFF.Checked)
            {
                initTTS();
                speaker.Speak("Задача удалена");
            }
            else
            {
                return;
            }
        }

        private void isCheckedTrue()
        {
            string connection = @"Data Source=c:\\sqlite\\taskdb.db;Version=3";
            SQLiteConnection sqlite_conn = new SQLiteConnection(connection);

            var stringQuery = $"UPDATE task set Done='{1}' WHERE id='{this.taskDataGridView.SelectedRows[0].Cells[0].Value.ToString()}'";
            sqlite_conn.Open();//Open the SqliteConnection
            var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
            SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
            SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
            SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
            sqlite_conn.Close();//Close the SqliteConnection
        }

        private void isCheckedFalse()
        {
            string connection = @"Data Source=c:\\sqlite\\taskdb.db;Version=3";
            SQLiteConnection sqlite_conn = new SQLiteConnection(connection);

            var stringQuery = $"UPDATE task set Done='{0}' WHERE id='{this.taskDataGridView.SelectedRows[0].Cells[0].Value.ToString()}'";
            sqlite_conn.Open();//Open the SqliteConnection
            var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
            SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
            SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
            SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
            sqlite_conn.Close();//Close the SqliteConnection
        }

        private void Timer_elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = DateTime.Parse(taskDataGridView.SelectedCells[2].Value.ToString());

            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                try
                {
                    if (ttsONOFF.Checked)
                    {
                        initTTS();
                        speaker.Speak("Задание   " + taskDataGridView.CurrentCell.Value.ToString() + "... выполнено");
                        toolStripStatusLabel1.Text = "Stop";
                        soundPlayer.SoundLocation = ".\\bb.wav";
                        soundPlayer.PlayLooping();
                    }
                    else
                    {

                        toolStripStatusLabel1.Text = "Stop";
                        soundPlayer.SoundLocation = ".\\bb.wav";
                        soundPlayer.PlayLooping();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            INIManager manager = new INIManager(".\\my.ini");
            ttsONOFF.Checked = Convert.ToBoolean(manager.GetPrivateString("main", "onoffTTS"));
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_elapsed;

            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            updateButton.PerformClick();
            if (taskDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Данные не заполнены!");
            }
            else
            {
                taskDataGridView.CurrentCell = null;
                foreach (DataGridViewRow row in taskDataGridView.Rows)
                {
                    if ((row.Cells[3].Value != null) && (row.Cells[3].Value.ToString() == "1"))
                    {
                        row.Visible = false;
                    }
                }

                foreach (DataGridViewRow row in taskDataGridView.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "0")
                    {
                        taskDataGridView.Focus();
                        taskDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    }
                }

                timer.Start();
                toolStripStatusLabel1.Text = " Running... ";
                btnStart.Enabled = false;

                toolStripStatusLabel3.Text = " Ждем выполнения задачи: " + taskDataGridView.CurrentCell.Value.ToString();

                if (ttsONOFF.Checked)
                {
                    initTTS();
                    speaker.Speak("Таймер запущен");
                }
                else
                {
                    return;
                }

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            timer.Stop();
            soundPlayer.Stop();
            toolStripStatusLabel1.Text = "Stop";



            var result = MessageBox.Show(@" Задание выполнено ?", "Подтвердить", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    isCheckedTrue();
                    break;
                case DialogResult.No:
                    isCheckedFalse();
                    break;
                default:
                    break;
            }

            updateButton.PerformClick();

            if (ttsONOFF.Checked)
            {
                initTTS();
                speaker.Speak("Таймер остановлен");
            }
            else
            {
                return;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateDataBase();
        }

        public void UpdateDataBase()
        {
            this.CustomizeDataGridView();
            SQLiteConnection myconnection = new SQLiteConnection("Data Source=c:\\sqlite\\taskdb.db; Version=3");
            myconnection.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = myconnection;
            cmd.CommandText = "Select * from Task";

            using (SQLiteDataReader sdr = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(sdr);
                sdr.Close();
                myconnection.Close();
                taskDataGridView.DataSource = dt;
            }
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();

            notifyIcon1.BalloonTipTitle = "Программа свернута";
            notifyIcon1.BalloonTipText = "Обратите внимание что программа была спрятана в трей и продолжит свою работу.";
            notifyIcon1.ShowBalloonTip(2000);

            if (timer.Enabled)
            {
                notifyIcon1.Text = "Таймер запущен!";
            }
            else
            {
                notifyIcon1.Text = "Таймер остановлен!";
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;

        }


        private void taskDataGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            toolStripStatusLabel2.Text = " Количество строк в БД: " + taskDataGridView.Rows.Count.ToString() + " - Видимых строк: " + taskDataGridView.DisplayedRowCount(true).ToString();
        }

        public void initTTS()
        {
            INIManager manager = new INIManager(".\\my.ini");
            speaker.SetOutputToDefaultAudioDevice();
            speaker.SelectVoice("IVONA 2 Tatyana");
            speaker.Rate = Convert.ToInt32(manager.GetPrivateString("main", "speedTTS"));
            speaker.Volume = 100;
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            INIManager manager = new INIManager(".\\my.ini");
            string htime = DateTime.Now.Hour.ToString();
            int stim = Convert.ToInt16(htime);


            if (stim >= 0 && stim <= 3)
            {
                if (ttsONOFF.Checked)
                {
                    initTTS();
                    speaker.Speak("Доброй ночи" + manager.GetPrivateString("main", "name"));
                }
                else
                {
                    return;
                }

            }

            else if (stim >= 4 && stim <= 11)
            {
                if (ttsONOFF.Checked)
                {
                    initTTS();
                    speaker.Speak("Доброе утро" + manager.GetPrivateString("main", "name"));
                }
                else
                {
                    return;
                }
            }

            else if (stim >= 12 && stim <= 16)
            {
                if (ttsONOFF.Checked)
                {
                    initTTS();
                    speaker.Speak("Добрый день" + manager.GetPrivateString("main", "name"));
                }
                else
                {
                    return;
                }
            }

            else if (stim >= 17 && stim <= 23)
            {
                if (ttsONOFF.Checked)
                {
                    initTTS();
                    speaker.Speak("Добрый вечер" + manager.GetPrivateString("main", "name"));
                }
                else
                {
                    return;
                }
            }

            else
                return;
        }
    }
}
