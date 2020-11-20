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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void txtRegNumber_TextChanged(object sender, EventArgs e)
        {
            if(txtRegNumber.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConnectionString.connectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"Select fname,mname,duration from NewAdmission where NAID = '{txtRegNumber.Text}'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                if(DS.Tables[0].Rows.Count != 0)
                {
                    fnameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    mnameLabel.Text = DS.Tables[0].Rows[0][1].ToString();
                    durationLabel.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    fnameLabel.Text = "______";
                    mnameLabel.Text = "______";
                    durationLabel.Text = "______";
                }
            }
            else
            {
                txtRegNumber.Text = "";
                txtRegNumber.Text = "";
                fnameLabel.Text = "______";
                mnameLabel.Text = "______";
                durationLabel.Text = "______";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString.connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"select * from fees where NAID = '{txtRegNumber.Text}'";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            if(DS.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection();
                con.ConnectionString = ConnectionString.connectionString;
                SqlCommand cmd1 = new SqlCommand();
                cmd.Connection = con1;

                cmd.CommandText = $"Insert into fees (NAID,fees) values ('{txtRegNumber.Text}','{txtFees.Text}')";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                if (MessageBox.Show("Fees Submition Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegNumber.Text = "";
                    txtFees.Text = "";
                    fnameLabel.Text = "______";
                    mnameLabel.Text = "______";
                    durationLabel.Text = "______";
                }
            }
            else
            {
                MessageBox.Show("Fees in already submited");
                txtRegNumber.Text = "";
                txtFees.Text = "";
                fnameLabel.Text = "______";
                mnameLabel.Text = "______";
                durationLabel.Text = "______";
            }
        }
    }
}
