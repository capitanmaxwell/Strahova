using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data.SqlTypes;
using NpgsqlTypes;

namespace КПЗ
{
    /*public static class GV
    {
        public static string loginuser;
    }*/
    public partial class Form1 : Form
    {        
        public Form1()
        {
                InitializeComponent();                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += new EventHandler((_s, _e) =>
            {
                timer.Stop();
                timer.Dispose();

                // какие-то действия ПОСЛЕ
                form2.Hide();
                Form3 form3 = new Form3();
                form3.Show();
            });

            timer.Start();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NpgsqlConnection dbc = new NpgsqlConnection("Server=localhost;Port=5432;Database=admin;User Id=postres;Password=5106690;");
            //NpgsqlDataAdapter abd = new NpgsqlDataAdapter("select * from users Login=" +textBox1.Text+" and password="+textBox2.Text+"", dbc);
            //DataTable dt = new DataTable();
            //abd.Fill(dt);
            bool blnfound = true;

            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from public.\"Users\" where \"Login\"= '" + textBox1.Text + "' and \"Password\" = '" + textBox2.Text + "'", con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                GV.loginuser = textBox1.Text;
                Form2 form2 = new Form2();
                    form2.Show();

                    Timer timer = new Timer();
                    timer.Interval = 3000;
                    timer.Tick += new EventHandler((_s, _e) =>
                    {
                        timer.Stop();
                        timer.Dispose();

                        // какие-то действия ПОСЛЕ
                        form2.Hide();
                        Form5 form5 = new Form5();
                        form5.Show();
                    });

                    timer.Start();
                    Hide();                
            }
            else blnfound = false;

            if (blnfound == false)
            {
                MessageBox.Show("Спробуй ще раз:); ", " bla bla ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            dr.Close();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += new EventHandler((_s, _e) =>
            {
                timer.Stop();
                timer.Dispose();

                // какие-то действия ПОСЛЕ
                form2.Hide();
                Form7 form7 = new Form7();
                form7.Show();
            });

            timer.Start();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += new EventHandler((_s, _e) =>
            {
                timer.Stop();
                timer.Dispose();

                // какие-то действия ПОСЛЕ
                form2.Hide();
                Form8 form8 = new Form8();
                form8.Show();
            });

            timer.Start();
            Hide();
        }
    }
}
