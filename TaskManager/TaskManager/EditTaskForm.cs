using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class EditTaskForm : Form
    {
        public string taskText { get; set; }
        public string dateTask { get; set; }
        public string detailTask { get; set; }
        public string dataStringGridView { get; set; }

        public string isCheckedData { get; set; }
        public string isImpTask { get; set; }


        public EditTaskForm(string taskText, string dateTask, string detailTask, string dataStringGridView, string isCheckedData, string isImpTask)
        {
            InitializeComponent();
            this.titleTextBox.Text = taskText;

            doDatePicker.Format = DateTimePickerFormat.Custom;
            doDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.doDatePicker.Value = DateTime.Parse(dateTask);
            label1.Text = dataStringGridView;
            detailsTextBox.Text = detailTask;
           
            label2.Text = isCheckedData;
            label3.Text = isImpTask;

            if (label2.Text == "1")
            {
                isCompletedCheckBox.Checked = true;
               
            }
            else
            {
                isCompletedCheckBox.Checked = false;
            }

            if( label3.Text == "1")
            {
                isImpTaskCheckBox.Checked = true;
            }
            else
            {
                isImpTaskCheckBox.Checked = false;
            }
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

            // task, doDate, Details, Done   столбцы таблицы

            //  var stringQuery = $"UPDATE Task set task='{this.titleTextBox.Text}' WHERE id='{dataStringGridView}'";
            var stringQuery = $"UPDATE task set Task='{this.titleTextBox.Text}', doDate='{this.doDatePicker.Text}', Details='{this.detailsTextBox.Text}', Done='{i}' WHERE id='{this.label1.Text}'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(isCompletedCheckBox.Checked);
            var stringQuery = $"UPDATE task set Task='{this.titleTextBox.Text}', doDate='{this.doDatePicker.Text}', Details='{this.detailsTextBox.Text}', Done='{i}' WHERE id='{this.label1.Text}'";
            textBox1.Text = stringQuery;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*     string theDate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " ";  //"yyyy-MM-dd"
                 string theTime = doDatePicker.Value.ToString("HH:mm:ss");

                 doDatePicker.Format = DateTimePickerFormat.Custom;
                 doDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";

                 doDatePicker.Value = DateTime.Parse(theDate + theTime);
            */

            string theDate = DateTime.Now.ToString("yyyy-MM-dd");

            TimeSpan theTime = doDatePicker.Value.TimeOfDay;
            DateTime dtNew = DateTime.Now.Date + theTime;

            //label3333333.Text = dtNew.ToString("yyyy-MM-dd HH:mm:ss");

            doDatePicker.Format = DateTimePickerFormat.Custom;
            doDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            doDatePicker.Value = dtNew;


            isCompletedCheckBox.Checked = false;
        }

        private void EditTaskForm_Load(object sender, EventArgs e)
        {
            if (isImpTaskCheckBox.Checked == true)
            {
                MessageBox.Show("Важная заявка - не редактируема!", "Ошибка");
                okButton.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void isImpTaskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(isImpTaskCheckBox.Checked == false)
            {
                okButton.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
