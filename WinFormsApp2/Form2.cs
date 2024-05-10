using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;

namespace WinFormsApp2
{
    
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;database=inventorydatabase;username=root;password=''");


        
        DataTable inventory = new DataTable();
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stocknametextBox.Clear();
            stockcodetextBox.Clear();
            quantitytextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool dup = false;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM stocklevel", connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {

                String name = stocknametextBox.Text;
                String code = stockcodetextBox.Text;
                int qyt = Convert.ToInt32(quantitytextBox.Text);

                if (name == "" || code == "")
                {

                    MessageBox.Show("All field are required");
                }

                else
                {
                    while (reader.Read())
                    {
                        if (code == reader.GetString("Stockcode"))
                        {
                            dup = true;
                            break;
                        }

                    }

                    if (dup == true)
                    {
                        MessageBox.Show("Stock item already exist");
                    }
                    else
                    {
                        transactionlog log = new transactionlog(name, code, qyt, DateTime.Now);
                        Stock skt = new Stock(name, code, qyt);

                        skt.Addstock();
                        log.Additem();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
