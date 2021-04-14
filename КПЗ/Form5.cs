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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            NpgsqlCommand cmdc = new NpgsqlCommand();
            cmdc.Connection = con;
            cmdc.CommandType = CommandType.Text;
            cmdc.CommandText = "SELECT * FROM \"Contracts\" WHERE \"Contracts\".\"UserName\" = '" + GV.loginuser + "'";
            NpgsqlDataReader drc = cmdc.ExecuteReader();
            if (drc.HasRows)
            {
                DataTable dtc = new DataTable();
                dtc.Load(drc);
                dataGridView1.DataSource = dtc;
            }
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
                Form7 form7 = new Form7();
                form7.Show();
            });

            timer.Start();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddContract AddContract = new AddContract();
            AddContract.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            NpgsqlCommand cmdc = new NpgsqlCommand();
            cmdc.Connection = con;
            cmdc.CommandType = CommandType.Text;
            cmdc.CommandText = "Delete from public.\"Contracts\" WHERE \"Id\" = '" + dataGridView1.RowCount + "'";
            cmdc.ExecuteNonQuery();
        }
    }
}
