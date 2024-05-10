using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;

class Stock
{
    private string stockname;
    private string stockcode;
    private int stockquantity;

  

    public Stock(string name, string code, int qyt)
    {
        this.stockname = name;
        this.stockcode = code;
        this.stockquantity = qyt;
    }

  
    public string Getname()
    {
        return stockname;
    }

    public string Getcode()
    {
        return stockcode;
    }
    public int Getqyt()
    {
        return stockquantity;
    }
    MySqlConnection connection = new MySqlConnection("datasource=localhost;database=inventorydatabase;username=root;password=''");


    public void Addstock()  
    {
        string con_level = "INSERT INTO stocklevel(`Stockname`, `Stockcode`, `Quantity`) VALUES('" + Getname() + "', '" + Getcode() + "', '" + Getqyt() + "')";
        connection.Open();
        MySqlCommand command = new MySqlCommand(con_level, connection);

        if (command.ExecuteNonQuery() == 1)
        {
            MessageBox.Show("Data inserted");
        }
        else
        {
            MessageBox.Show("Data not inserted");
        }
        connection.Close();
    }
}
