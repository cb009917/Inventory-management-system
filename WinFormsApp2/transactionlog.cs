using System;
using MySql.Data.MySqlClient;

class transactionlog : Stock
{

    public DateTime time { get; set; }

    public transactionlog(string name, string code, int qyt, DateTime time) : base(name, code, qyt)
    {
        this.time = time;
    }
    MySqlConnection connection = new MySqlConnection("datasource=localhost;database=inventorydatabase;username=root;password=''");

    
    public void Additem()
    {
        string action = "Data Added";
        connection.Open();
        string con_log = "INSERT INTO transactionlog(`Stockname`, `Stockcode`, `Quantity`,`Action`) VALUES('" + Getname() + "', '" + Getcode() + "', '" + Getqyt() + "', '" + action + "')";
        MySqlCommand command_log = new MySqlCommand(con_log, connection);
        command_log.ExecuteNonQuery();
        connection.Close();
    }
}


