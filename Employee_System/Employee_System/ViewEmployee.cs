using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_System
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-6LHATRM\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from  Employee_Table where EmpId='" + empidsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                empidlbl.Text = dr["Empid"].ToString();
                empnamelbl.Text = dr["Empname"].ToString();
                empaddlbl.Text = dr["Empadd"].ToString();
                empposlbl.Text = dr["Emppos"].ToString();
                empdoblbl.Text = dr["Empdob"].ToString();
                empphonelbl.Text = dr["Empphone"].ToString();
                empedilbl.Text = dr["Empedu"].ToString();
                empgenlbl.Text = dr["Empgen"].ToString();
                empidlbl.Visible = true;
                empnamelbl.Visible = true;
                empaddlbl.Visible = true;
                empposlbl.Visible = true;
                empdoblbl.Visible = true;
                empphonelbl.Visible = true;
                empedilbl.Visible = true;
                empgenlbl.Visible = true;
            }
            Con.Close();
           
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            empidlbl.Visible = false;
            empnamelbl.Visible = false;
            empaddlbl.Visible = false;
            empposlbl.Visible = false;
            empdoblbl.Visible = false;
            empphonelbl.Visible = false;
            empedilbl.Visible = false;
            empgenlbl.Visible = false;
            empidsearch.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("=======EMPLOYEE SUMMARY=======", new Font("Times New Roman",20,FontStyle.Bold),Brushes.Red,new Point(170));
            e.Graphics.DrawString("Employee ID:  " +empidlbl.Text+ "\tEmployee Name:  " +empnamelbl.Text, new Font("Times New Roman",18,FontStyle.Bold),Brushes.Blue,new Point(50,100));
            e.Graphics.DrawString("Employee Address:  " + empaddlbl.Text + "\tEmployee Gender:  " + empgenlbl.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 200));
            e.Graphics.DrawString("Employee Position:  " + empposlbl.Text + "\tEmployee DOB:  " + empdoblbl.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 300));
            e.Graphics.DrawString("Employee Phone:  " + empphonelbl.Text + "\tEmployee Education:  " + empedilbl.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 400));
            e.Graphics.DrawString("=======4GBx SOLUTIONS=======", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Red, new Point(170,500));

        }
    }
}
