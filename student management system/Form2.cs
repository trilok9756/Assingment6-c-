using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace GLA_Management_System
{
    public partial class Form2 : Form
    {
        public static string idn,p;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string person,details;
             idn = Form1.idno;
             p = Form1.prs;
            if (p == "Faculty")
            {
                person = "faculty";
            }
            else
            {
                person = "student";
            }
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from "+person+ " where id=@i", connection);
            textBox1.Text = idn;
            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(textBox1.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (person == "student")
            {
                 details = "Roll no : - " + dr.GetValue(1).ToString() + "" +
                    "\n Name : - " + dr.GetValue(2).ToString() + "\n Course :- " + dr.GetValue(3).ToString();
                
            }
            else
            {
                details = "Name : - " + dr.GetValue(1).ToString() + " \n" + " Department :- " + dr.GetValue(2).ToString();
            }
            richTextBox1.Text = details;

            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from student where id=@i", connection);
            textBox1.Text = idn;
            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(textBox1.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string details = "Roll no : - "+ dr.GetValue(1).ToString()+"" +
                "\n Name : - "+ dr.GetValue(2).ToString()+"\n Course :- "+ dr.GetValue(3).ToString();
            richTextBox1.Text = details;
            
            connection.Close();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = idn;
        }
    }
}
