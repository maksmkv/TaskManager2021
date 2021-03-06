﻿
namespace TaskManager
{
    partial class EditTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.isCompletedCheckBox = new System.Windows.Forms.CheckBox();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.doDatePicker = new System.Windows.Forms.DateTimePicker();
            this.lblTask = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.isImpTaskCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(510, 299);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(415, 299);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // isCompletedCheckBox
            // 
            this.isCompletedCheckBox.AutoSize = true;
            this.isCompletedCheckBox.Location = new System.Drawing.Point(14, 303);
            this.isCompletedCheckBox.Name = "isCompletedCheckBox";
            this.isCompletedCheckBox.Size = new System.Drawing.Size(83, 17);
            this.isCompletedCheckBox.TabIndex = 15;
            this.isCompletedCheckBox.Text = "Выполнено";
            this.isCompletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Location = new System.Drawing.Point(14, 64);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(571, 222);
            this.detailsTextBox.TabIndex = 14;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(11, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(115, 15);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Дата выполнения:";
            // 
            // doDatePicker
            // 
            this.doDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.doDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.doDatePicker.Location = new System.Drawing.Point(167, 38);
            this.doDatePicker.Name = "doDatePicker";
            this.doDatePicker.Size = new System.Drawing.Size(196, 20);
            this.doDatePicker.TabIndex = 12;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTask.Location = new System.Drawing.Point(11, 15);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(52, 15);
            this.lblTask.TabIndex = 11;
            this.lblTask.Text = "Задача:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(69, 12);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(516, 20);
            this.titleTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(390, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Текущая дата/снять флаг";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // isImpTaskCheckBox
            // 
            this.isImpTaskCheckBox.AutoSize = true;
            this.isImpTaskCheckBox.Location = new System.Drawing.Point(103, 303);
            this.isImpTaskCheckBox.Name = "isImpTaskCheckBox";
            this.isImpTaskCheckBox.Size = new System.Drawing.Size(71, 17);
            this.isImpTaskCheckBox.TabIndex = 24;
            this.isImpTaskCheckBox.Text = "Важное?";
            this.isImpTaskCheckBox.UseVisualStyleBackColor = true;
            this.isImpTaskCheckBox.CheckedChanged += new System.EventHandler(this.isImpTaskCheckBox_CheckedChanged);
            // 
            // EditTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 345);
            this.Controls.Add(this.isImpTaskCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.isCompletedCheckBox);
            this.Controls.Add(this.detailsTextBox);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.doDatePicker);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.titleTextBox);
            this.Name = "EditTaskForm";
            this.Text = "Редактировать задачу";
            this.Load += new System.EventHandler(this.EditTaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox isCompletedCheckBox;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker doDatePicker;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isImpTaskCheckBox;
    }
}