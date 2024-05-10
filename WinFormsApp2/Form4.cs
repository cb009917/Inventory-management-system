using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;

namespace WinFormsApp2
{

    public partial class Form4 : Form
    {
        string conn = $"datasource=localhost;database=inventorydatabase;username=root;password=''";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (MySqlConnection hero = new MySqlConnection(conn))
            {
                bool login = false;
                string user = textBox1.Text;
                string passwd = textBox2.Text;

                hero.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM login", hero);
                MySqlDataReader reader = cmd.ExecuteReader();

                
                    while (reader.Read())
                    {
                        if (user == reader.GetString("Username") && passwd == reader.GetString("Password"))
                        {
                       
                        login = true;
                            break;
                        }

                    }
               
                if(login == true)
                {
                   
                    Form1 form = new Form1();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentionals");
                }
            }
        }
    }
}
