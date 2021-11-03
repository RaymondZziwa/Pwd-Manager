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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=Admin;Initial Catalog=pwdmng;Integrated Security=True");
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginclick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select username,pwd from Owner where username='" + uname.Text + "'and pwd='" + pwd.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                PwdSearch pwds = new PwdSearch();
                pwds.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login.Please check username and password.");
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
