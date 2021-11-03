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

namespace Password_Manager
{
    public partial class PwdSearch : Form
    {
        public PwdSearch()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=Admin;Initial Catalog=pwdmng;Integrated Security=True");
        private void retrieveClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select Password from Pwds where Application ='" + app.Text + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                revpwd.Text = dr.GetValue(0).ToString();
            }
            else
            {
                MessageBox.Show("No password saved for this particular application/website.");
            }
            con.Close();

        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login logobj = new Login();
            logobj.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(revpwd.Text))
            {
                MessageBox.Show("You left the password box blank.");
            }
            else
            {
                con.Open();
                SqlCommand comm = new SqlCommand("Insert into Pwds(Application,Password) values('" + app.Text + "','" + revpwd.Text + "')", con);
                comm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"Your password for {app.Text} has been successfully saved.");  
            }
        }
    }
}
