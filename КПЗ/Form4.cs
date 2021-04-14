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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            NpgsqlConnection user = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            user.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = user;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from public.\"Users\"";
            NpgsqlDataReader dru = cmd.ExecuteReader();
            if(dru.HasRows)
            {
                DataTable dtu = new DataTable();
                dtu.Load(dru);
                dataGridView2.DataSource = dtu;
            }

            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            NpgsqlCommand cmdc = new NpgsqlCommand();
            cmdc.Connection = con;
            cmdc.CommandType = CommandType.Text;
            cmdc.CommandText = "Select * from public.\"Contracts\"";
            NpgsqlDataReader drc = cmdc.ExecuteReader();
            if (drc.HasRows)
            {
                DataTable dtc = new DataTable();
                dtc.Load(drc);
                dataGridView1.DataSource = dtc;
            }

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            conn.Open();
            NpgsqlCommand cmdcn = new NpgsqlCommand();
            cmdcn.Connection = conn;
            cmdcn.CommandType = CommandType.Text;
            cmdcn.CommandText = "Select * from public.\"Agents\"";
            NpgsqlDataReader drcc = cmdc.ExecuteReader();
            if (drcc.HasRows)
            {
                DataTable dtcc = new DataTable();
                dtcc.Load(drcc);
                dataGridView3.DataSource = dtcc;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                    AddUser AddUser = new AddUser();
                    AddUser.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres; User Id=postgres;Password=5106690");
            con.Open();
            NpgsqlCommand cmdc = new NpgsqlCommand();
            cmdc.Connection = con;
            cmdc.CommandType = CommandType.Text;
            cmdc.CommandText = "Delete from public.\"Users\" WHERE \"Id\" = '" + dataGridView2.RowCount + "'";
            cmdc.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddAgent AddAgent = new AddAgent();
            AddAgent.Show();
        }
    }
}
