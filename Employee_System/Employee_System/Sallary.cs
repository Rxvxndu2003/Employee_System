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
    public partial class Sallary : Form
    {
        public Sallary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-6LHATRM\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        private void fetchempdata()
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter Employee ID");
            }
            else
            {
                Con.Open();
                string query = "select * from  Employee_Table where EmpId='" + EmpIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EmpNameTb.Text = dr["Empname"].ToString();
                    EmpPosTb.Text = dr["Emppos"].ToString();



                }
                Con.Close();
            }
           

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Sallary_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        int Dailybase,total;
        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpPosTb.Text == "")
            {
                MessageBox.Show("Select An Employee");
            }
            else if (WorkedTb.Text == "" || Convert.ToInt32(WorkedTb.Text) > 28)
            {
                MessageBox.Show("Enter A VAlid Number of Days");
            }
            else
            {
                if (EmpPosTb.Text == "Junior Developer")
                {
                    Dailybase = 4000;
                }
                else if (EmpPosTb.Text == "Senoir Developer")
                {
                    Dailybase = 3800;
                }else if (EmpPosTb.Text == "Manager")
                {
                    Dailybase = 3500;
                } else if (EmpPosTb.Text == "Accountant")
                {
                    Dailybase = 3000;
                }else
                {
                    Dailybase = 1000;
                }
                total = Dailybase * Convert.ToInt32(WorkedTb.Text);
                SalarySlip.Text = "Employee ID:" +EmpIdTb.Text + "\n" + "Employee Name:" +EmpNameTb.Text + "\n" + "Employee Position:" + EmpPosTb.Text + "\n" + "Worked Days:" +WorkedTb.Text + "\n" + "Daily amount:" +Dailybase + "\n" + "Total Amount:" +total;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmpIdTb.Clear();
            EmpNameTb.Clear();
            EmpPosTb.Clear();
            WorkedTb.Clear();
            SalarySlip.Clear();

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
            e.Graphics.DrawString("=======EMPLOYEE SALARY=======", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Red, new Point(170));
            e.Graphics.DrawString("Employee ID:  " + EmpIdTb.Text , new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 100));
            e.Graphics.DrawString("Employee Name:  " + EmpNameTb.Text , new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 200));
            e.Graphics.DrawString("Employee Position:  " + EmpPosTb.Text , new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 300));
            e.Graphics.DrawString("Worked Days:  " + WorkedTb.Text , new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 400));
            e.Graphics.DrawString("Daily Amount:  " + Dailybase, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 500));
            e.Graphics.DrawString("Total Amount:  " + total, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Blue, new Point(50, 600));
            e.Graphics.DrawString("=======4GBx SOLUTIONS=======", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Red, new Point(170, 700));
        }
    }
}
