using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        string conn= $"datasource=localhost;database=inventorydatabase;username=root;password=''";
        DataTable log = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {



            using (MySqlConnection sqlconn = new MySqlConnection(conn))
            {

                sqlconn.Open();
                MySqlDataAdapter sqldat = new MySqlDataAdapter("SELECT * FROM transactionlog", sqlconn);
                sqldat.Fill(log);

                dataGridView1.DataSource = log;

            }


        }
    }
}
