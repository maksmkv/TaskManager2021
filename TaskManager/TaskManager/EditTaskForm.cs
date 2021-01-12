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

namespace TaskManager
{
    public partial class EditTaskForm : Form
    {
        public string taskText { get; set; }
        public string dateTask { get; set; }
        public string detailTask { get; set; }

        public string dataStringGridView { get; set; }
        public EditTaskForm(string taskText, string dateTask, string detailTask, string dataStringGridView)
        {
            InitializeComponent();
            this.titleTextBox.Text = taskText;

            doDatePicker.Format = DateTimePickerFormat.Custom;
            doDatePicker.CustomFormat = "dd:MM:yyyy HH:mm:ss";
            this.doDatePicker.Value = DateTime.Parse(dateTask);

            detailsTextBox.Text = detailTask;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=c:\\sqlite\\taskdb.db;Version=3";
            SQLiteConnection sqlite_conn = new SQLiteConnection(connection);

            int i = Convert.ToInt32(isCompletedCheckBox.Checked);

            // cmd.CommandText = "update Student set FirstName='" + textBox2.Text + "',LastName='" + textBox3.Text + "' where ID=" + textBox1.Text + "";

            var stringQuery =  $"UPDATE task SET Task='{this.titleTextBox.Text}', doDate='{this.doDatePicker.Text}', Details='{this.detailsTextBox.Text}', Done='{i}' WHERE id={this.dataStringGridView};";
            //   string stringQuery = "UPDATE task set Task='" + this.titleTextBox.Text + "',doDate='" + this.doDatePicker.Text + "',Details='" + this.detailsTextBox.Text + "',Done='" + i+ "' WHERE id=" + dataStringGridView + "";
            sqlite_conn.Open();//Open the SqliteConnection
            var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
            SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
            SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
            SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
            sqlite_conn.Close();//Close the SqliteConnection
            this.Close();
        }
    }
}
