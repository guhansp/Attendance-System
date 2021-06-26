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
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public bool loginFlag { get; set; }
        public int UserID { get; set;  }
        public LoginForm()
        {
            InitializeComponent();
            loginFlag = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.UsersTableAdapter userAda = new DataSet1TableAdapters.UsersTableAdapter();
            DataTable dt = userAda.GetDataByUserAndPass(metroTextBoxUser.Text, metroTextBoxPass.Text);

            if(dt.Rows.Count > 0)
            {
                // valid login
                MessageBox.Show("Login Sucessful");
                UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                loginFlag = true;
                

            }
            else
            {
                // not valid
                MessageBox.Show("Acess Denied");
                loginFlag = false;
            }
            Close();
        }


        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
