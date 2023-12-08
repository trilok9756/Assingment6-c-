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
using System.Data.SqlClient;

namespace GLA_Management_System
{
    public partial class Form3 : Form
    {
        public static string ir;
        public Form3()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into student values(@i,@r,@n,@c)", connection);

            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@r", Convert.ToInt32(textBox2.Text));
            cmd.Parameters.AddWithValue("@n", textBox3.Text);
            cmd.Parameters.AddWithValue("@c", textBox4.Text);

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                label6.Text = "Record Inserted";
            else
                label6.Text = "Failed";
            connection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ir = Form1.idno;
            textBox1.Text = ir;
        }
    }
}
