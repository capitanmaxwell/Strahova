using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace КПЗ
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            if (textBox2.Text == textBox3.Text)
            {
                /*NpgsqlCommand cmd = new NpgsqlCommand("insert into public.\"Users\" values (nextval(\"Id\"), + '" + textBox1.Text + "' , '" + textBox2.Text + "');", con);
                cmd.ExecuteNonQuery();*/
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Users\"(\"Login\",\"Password\") VALUES ('"+ textBox1.Text + "','"+ textBox2.Text +"')", con);
                cmd.ExecuteNonQuery();
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
        }
    }
}
