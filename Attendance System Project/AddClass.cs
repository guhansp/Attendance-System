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
    public partial class AddClass : Form
    {
        public int UserID { get; set; }



        public AddClass()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.ClassTableTableAdapter ada = new DataSet1TableAdapters.ClassTableTableAdapter();
            ada.Addclass(metroTextBox1.Text, UserID);
            Close();
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            
        }
    }
}
