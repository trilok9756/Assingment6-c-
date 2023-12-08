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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace GLA_Management_System
{
    public partial class Form4 : Form
    {
        public static string ir;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into faculty values(@i,@n,@d)", connection);

            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@n", textBox2.Text);
            cmd.Parameters.AddWithValue("@d", textBox3.Text);
           

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
                label5.Text = "Record Inserted";
            else
                label5.Text = "Failed";
            connection.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ir = Form1.idno;
            textBox1.Text = ir;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
