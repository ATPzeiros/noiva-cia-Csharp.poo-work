using System.Data;
using System.Data.SQLite;

class Database {
    private static SQLiteConnection sQLiteConnection;
    private static String dbPath = System.IO.Directory.GetCurrentDirectory() + "/persistence/noiva_cia.db";

    public static void CreateDatabaseIfNotExists(){
        try{
            SQLiteConnection.CreateFile(dbPath);
        }catch{
            throw;
        }
    }

    public static SQLiteConnection DbConnection(){
        sQLiteConnection = new SQLiteConnection($"Data Source={dbPath}; Version=3;");
        sQLiteConnection.Open();
        return sQLiteConnection;
    }

    public static void CreateTable(){
        try {
            using var cmd = DbConnection().CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Clientes(id int, Nome Varchar(50), email VarChar(80))";
            cmd.ExecuteNonQuery();
        } catch(Exception ex) {
            throw ex;
        }
    }

    public static void Add()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Clientes(id, Nome, email ) values ('1', 'Eu', 'eueu.com')";
                    //cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    //cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    //cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetClientes()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clientes";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
}