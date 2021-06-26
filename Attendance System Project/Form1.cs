using Attendance_System_Project.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_System_Project
{
    
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public int loggedIn { get; set; }
        public int UserID { get; set; }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.AttendanceTable' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'dataSet1.ClassTable' table. You can move, or remove it, as needed.



        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //Open Login Form
            if (loggedIn == 0)
            {
                LoginForm newLogin = new LoginForm();
                newLogin.ShowDialog();

                if (newLogin.loginFlag == false)
                {
                    Close();
                }
                else
                {
                    UserID = newLogin.UserID;
                    statLblUser.Text = UserID.ToString();
                    loggedIn = 1;
                    this.classTableTableAdapter.Fill(this.dataSet1.ClassTable);

                    classTableBindingSource.Filter = "UserID = '" + UserID.ToString() + "'";
                }
            }



        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            AddClass addclass = new AddClass();
            addclass.UserID = this.UserID;
            addclass.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            StudentsForm students = new StudentsForm();
            students.ClassName = metroComboBox1.Text;
            students.ClassID = (int)metroComboBox1.SelectedValue;
            students.ShowDialog();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonGet_Click(object sender, EventArgs e)
        {
            AttendanceTableTableAdapter ada = new AttendanceTableTableAdapter();
            DataTable dt = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            if(dt.Rows.Count>0)
            {
                //edit
                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;

            }
            else
            {
                //create
                StudentTableTableAdapter student_adapt = new StudentTableTableAdapter();
                DataTable dt_students = student_adapt.GetDataByClassID((int)metroComboBox1.SelectedValue);
                foreach(DataRow row in dt_students.Rows)
                {
                    ada.InsertQuery((int)row[0], (int)metroComboBox1.SelectedValue, dateTimePicker1.Text, "", row[1].ToString(), metroComboBox1.Text);

                }
                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;



            }


        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AttendanceTableTableAdapter ada = new AttendanceTableTableAdapter();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    ada.UpdateQuery(row.Cells[1].Value.ToString(), row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                }
            }
            DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AttendanceTableTableAdapter ada = new AttendanceTableTableAdapter();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    ada.UpdateQuery("", row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                }
            }
            DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;
        }
       
    }
}
