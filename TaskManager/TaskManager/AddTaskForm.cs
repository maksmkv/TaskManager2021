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
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=c:\\sqlite\\taskdb.db;Version=3";
            SQLiteConnection sqlite_conn = new SQLiteConnection(connection);

            //string Query = "insert into TbTexts(val1, val2) values('"+this.textBox1.Text + "','" + this.textBox2.Text + "')";

            int i = Convert.ToInt32(isCompletedCheckBox.Checked);

            string stringQuery = "insert into task(task, doDate, Details, Done) values('" + this.titleTextBox.Text + "','" + this.doDatePicker.Text + "' ,'" + this.detailsTextBox.Text + "','" + i + "'  )";
            sqlite_conn.Open();//Open the SqliteConnection
            var SqliteCmd = new SQLiteCommand();//Initialize the SqliteCommand
                SqliteCmd = sqlite_conn.CreateCommand();//Create the SqliteCommand
                SqliteCmd.CommandText = stringQuery;//Assigning the query to CommandText
                SqliteCmd.ExecuteNonQuery();//Execute the SqliteCommand
                sqlite_conn.Close();//Close the SqliteConnection
            this.Close();
            
            mainForm form = Application.OpenForms.OfType<mainForm>().FirstOrDefault();
            if (form != null)
            {
                form.UpdateDataBase();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
