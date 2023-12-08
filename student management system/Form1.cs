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
using System.Data.Sql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace GLA_Management_System
{
    public partial class Form1 : Form
    {
        public static string idno,prs,db,psw;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            idno = textBox1.Text;
            psw= textBox2.Text;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
            connection.Open();
            prs = comboBox1.Text;
            if (comboBox1.Text == "Faculty")
            {
                db = "facultykey";
            }
            else
            {
                db = "studentkey";
            }
            SqlCommand cmd = new SqlCommand("select *from " + db + " where id= @i and password= @p", connection);
            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(idno));
            cmd.Parameters.AddWithValue("@p", psw);
            SqlDataReader dr = cmd.ExecuteReader();
            Boolean c = dr.Read();

            connection.Close();
            if (c)
            {
                label5.Text = "Login Successfull";
                Form2 f2 = new Form2();
                prs = comboBox1.Text;
                f2.Show();
            }
            else
            {
                label5.Text = "Invalid User ID Or Password";
            }





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            idno = textBox1.Text;
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
            connection.Open();
            prs = comboBox1.Text;
            if (comboBox1.Text == "Faculty")
            {
                db = "facultykey";
            }
            else
            {
                db = "studentkey";
            }
            SqlCommand cmd1 = new SqlCommand("select *from " + db + " where id= @i", connection);
            cmd1.Parameters.AddWithValue("@i", Convert.ToInt32(idno));
            SqlDataReader dr = cmd1.ExecuteReader();
            Boolean c = dr.Read();
            connection.Close();
            if (c)
            {
                label5.Text = "User Already Registered";
            }
            else
            {
                SqlConnection connection1 = new SqlConnection("Data Source=DESKTOP-RRD8QAL\\SQLEXPRESS;Initial Catalog=\"GLAU database\";Integrated Security=True");
                connection1.Open();
                prs = comboBox1.Text;
                if (comboBox1.Text == "Faculty")
                {
                    db = "facultykey";
                }
                else
                {
                    db = "studentkey";
                }
                SqlCommand cmd = new SqlCommand("insert into " + db + " values(@u,@p)", connection1);
                
                cmd.Parameters.AddWithValue("@u", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@p", textBox2.Text);
                cmd.ExecuteNonQuery();
                connection1.Close();
                idno = textBox1.Text;

                if (prs == "Faculty")
                {
                    Form4 f4 = new Form4();
                    f4.Show();

                }
                else
                {
                    Form3 f3 = new Form3();
                    f3.Show();

                }
            }









           
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
