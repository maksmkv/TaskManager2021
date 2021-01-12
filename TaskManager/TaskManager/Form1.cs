// дела по https://docs.dataabstract.com/NET/Tutorials/TodoTutorial/defineschema/ 
// добавление SQLite3 в проект https://www.youtube.com/watch?v=Cdxz2mNr1a8
//https://stackoverflow.com/questions/19479166/sqlite-simple-insert-query/19489736
//https://stackoverflow.com/questions/31981757/how-to-insert-data-into-sqlite-database-using-c-sharp

//https://www.codeproject.com/Questions/708917/How-To-I-Delete-Selected-Rows-From-Datagrid-And-Da удаление строк рабочий вариант

//https://www.csharp-console-examples.com/database/connecting-c-application-to-sqlite-select-insert-update-delete/ UPDATE

//https://coderoad.ru/40379892/%D0%9F%D0%B5%D1%80%D0%B5%D0%B4%D0%B0%D1%87%D0%B0-%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B9-%D1%87%D0%B5%D1%80%D0%B5%D0%B7-%D1%84%D0%BE%D1%80%D0%BC%D1%8B-c      передача строк


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Timers;



namespace TaskManager
{
    
    public partial class mainForm : Form
    {

        System.Timers.Timer timer;
        readonly SoundPlayer soundPlayer = new SoundPlayer();

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
        }

        private void CustomizeDataGridView()
        {
            this.taskDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.taskDataGridView.MultiSelect = false;
            this.taskDataGridView.AutoGenerateColumns = false;

            this.taskDataGridView.ReadOnly = true;
            this.taskDataGridView.RowHeadersVisible = false;
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
            string taskText = taskDataGridView.SelectedCells[1].Value.ToString();
            string dateTask = taskDataGridView.SelectedCells[2].Value.ToString();
            string detailTask = taskDataGridView.SelectedCells[4].Value.ToString();
            string dataStringGridView = taskDataGridView.SelectedRows[0].Cells[0].Value.ToString();


            EditTaskForm EditForm = new EditTaskForm(taskText, dateTask, detailTask, dataStringGridView);
            EditForm.Show();
        }


        private void deleteTask_Click(object sender, EventArgs e)
        {
                      
            foreach (DataGridViewRow row in taskDataGridView.SelectedRows)
            {
                string connection = @"Data Source=c:\\sqlite\\taskdb.db;Version=3";
                SQLiteConnection sqlite_conn = new SQLiteConnection(connection);

                string stringQuery = "DELETE FROM Task WHERE id=" + this.taskDataGridView.SelectedRows[0].Cells[0].Value.ToString() +"";
                sqlite_conn.Open();//Open the SqliteConnection
                var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
                SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
                SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
                SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
                sqlite_conn.Close();
                taskDataGridView.Rows.Remove(row);
            }


        }

        private void Timer_elapsed(object sender, ElapsedEventArgs e)
        {
               DateTime currentTime = DateTime.Now;
               DateTime userTime = DateTime.Parse(taskDataGridView[2, 0].Value.ToString());

               if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
                  {
                      timer.Stop();
                      try
                      {
                          toolStripStatusLabel1.Text= "Stop";

                          soundPlayer.SoundLocation = @"c:\5\bb.wav";
                          soundPlayer.PlayLooping();
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                  }
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_elapsed;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            toolStripStatusLabel1.Text = "Running...";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            soundPlayer.Stop();
            toolStripStatusLabel1.Text = "Stop";
        }
    }
}
