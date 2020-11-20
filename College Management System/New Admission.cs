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
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fname = txtFullName.Text;
            string mname = txtMotherName.Text;
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
            string dob = dateTimePickerDOB.Text;
            int mobile = Convert.ToInt32(txtMobile.Text);
            string email = txtEmail.Text;
            string semester = txtSemester.Text;
            string program = txtProgramming.Text;
            string sname = txtSchoolName.Text;
            string duration = txtDuration.Text;
            string add = txtAddress.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString.connectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Insert into NewAdmission (fname , mname, gender, dob , mobile, email , semester , prog, sname , duration , address )" +
                $" values ('{fname}' , '{mname}' , '{gender}' , '{dob}' , {mobile} , '{email}' , '{semester}' , '{program}' , '{sname}' , '{duration}','{add}' )";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            MessageBox.Show("Data Saved .Remember the registration ID","Data",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";

            foreach (ComboBox comboBox in Controls.OfType<ComboBox>())
                comboBox.Text = "-- Select --";

            foreach (RadioButton radioButton in Controls.OfType<RadioButton>())
                radioButton.Checked = false;

            MessageBox.Show("All Items Cleard . ", "Success", MessageBoxButtons.OK);
        }

        private void New_Admission_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString.connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select max(NAID) from NewAdmission";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            Int64 abc = Convert.ToInt64(DS.Tables[0].Rows[0][0]);
            labelMax.Text = (abc+1).ToString(); // bodmas
        }
    }
}
