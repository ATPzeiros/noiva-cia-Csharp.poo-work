using SQLite;

static class DatabaseConnection
{
    private static SQLiteConnection? db = null;

    public static SQLiteConnection GetDatabase()
    {
        db ??= new SQLiteConnection(Directory.GetCurrentDirectory() + "/persistence/noiva_cia.db");
        return db;
    }
}
