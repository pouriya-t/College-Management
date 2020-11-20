using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string gender = "";
            bool isChecked = radioButtonMale.Checked;

            if (isChecked)
            {
                gender = radioButtonMale.Text;
            }
            else
            {
                gender = radioButtonFemale.Text;
            }


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString.connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"insert into Teacher (fname,gender,dob,mobile,email,semester,prog,yer,adr) " +
                $" values ( '{txtFName.Text}' , '{gender}' , '{dateTimePickerDOB.Text}' , {txtMobile.Text} , '{txtEmail.Text}', '{txtSemester.Text}', '{txtProgram.Text}' , '{txtDuration.Text}' , '{txtAddress.Text}' ) ";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);

            con.Close();

            MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
