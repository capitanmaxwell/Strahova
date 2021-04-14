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
    public partial class Form8 : Form
    {
        public Form8()
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
                Form1 form1 = new Form1();
                form1.Show();
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
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from public.\"Admin\" where \"Login\"= '" + textBox1.Text + "' and \"Password\" = '" + textBox2.Text + "'", con);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
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
                        Form4 form4 = new Form4();
                        form4.Show();
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
    }
}
