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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-6LHATRM\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Employee_Table values(" + EmpIdTb.Text + ",'" + EmpNameTb.Text + "','" + EmpAddTb.Text + "','" + EmpPosCb.SelectedItem.ToString() + "','" + Empdob.Value.Date + "','" + EmpPhoneTb.Text + "','" + EmpEduCb.SelectedItem.ToString() + "','" + EmpGenCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from Employee_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter the Employee Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Employee_Table where Empid = '" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //EmpIdTb.Text =  EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
            //EmpAddTb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            //EmpEduCb.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            //EmpPosCb.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
            //EmpPosCb.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            //EmpPhoneTb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            //EmpGenCb.Text = EmpDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (EmpDGV.SelectedRows.Count > 0)
            {
                // Access the selected row's cells
                EmpIdTb.Text = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
                EmpAddTb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
                EmpEduCb.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
                EmpPosCb.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
                EmpPosCb.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
                EmpPhoneTb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
                EmpGenCb.Text = EmpDGV.SelectedRows[0].Cells[7].Value.ToString();
            }
            else
            {
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update Employee_Table set Empname='" + EmpNameTb.Text + "',Empadd='" + EmpAddTb.Text + "',Emppos='" + EmpPosCb.SelectedItem.ToString() + "',Empdob='" + Empdob.Value.Date + "',Empphone='" + EmpPhoneTb.Text + "',Empedu='" + EmpEduCb.SelectedItem.ToString() + "',Empgen='" + EmpGenCb.SelectedItem.ToString() + "'where Empid='"+EmpIdTb.Text+"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated Successfully");
                    populate();
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmpIdTb.Clear();
            EmpNameTb.Clear();
            EmpAddTb.Clear();
            EmpPhoneTb.Clear();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
