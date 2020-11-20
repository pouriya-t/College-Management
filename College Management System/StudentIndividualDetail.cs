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
    public partial class StudentIndividualDetail : Form
    {
        public StudentIndividualDetail()
        {
            InitializeComponent();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString.connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"select * from NewAdmission where NAID = '{textBox1.Text}'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {


                fnameLabel.Text = ds.Tables[0].Rows[0][1].ToString();
                mnameLabel.Text = ds.Tables[0].Rows[0][2].ToString();
                genderLabel.Text = ds.Tables[0].Rows[0][3].ToString();
                dateOfBirthLabel.Text = ds.Tables[0].Rows[0][4].ToString();
                mobileLabel.Text = ds.Tables[0].Rows[0][5].ToString();
                emailLabel.Text = ds.Tables[0].Rows[0][6].ToString();
                standardLabel.Text = ds.Tables[0].Rows[0][7].ToString();
                mediumLabel.Text = ds.Tables[0].Rows[0][8].ToString();
                schoolLabel.Text = ds.Tables[0].Rows[0][9].ToString();
                yearLabel.Text = ds.Tables[0].Rows[0][10].ToString();
                addressLabel.Text = ds.Tables[0].Rows[0][11].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found", "No Match",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fnameLabel.Text = "______";
            mnameLabel.Text = "______";
            genderLabel.Text = "______";
            dateOfBirthLabel.Text = "______";
            mobileLabel.Text = "______";
            emailLabel.Text = "______";
            standardLabel.Text = "______";
            mediumLabel.Text = "______";
            schoolLabel.Text = "______";
            yearLabel.Text = "______";
            addressLabel.Text = "______";
        }
    }
}
