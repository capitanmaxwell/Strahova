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
    public partial class AddAgent : Form
    {
        public AddAgent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            if (textBox2.Text == textBox3.Text)
            {
                /*NpgsqlCommand cmd = new NpgsqlCommand("insert into public.\"Users\" values (nextval(\"Id\"), + '" + textBox1.Text + "' , '" + textBox2.Text + "');", con);
                cmd.ExecuteNonQuery();*/
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO public.\"Agents\"(\"Login\",\"Password\", \"FirstName\", \"LastName\", \"Phone\") VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                cmd.ExecuteNonQuery();
                Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
