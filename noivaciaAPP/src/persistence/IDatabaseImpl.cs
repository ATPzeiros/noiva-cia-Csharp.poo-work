using NoivaCiaApp.entity;
using NoivaCiaApp.persistence;
using SQLite;

class IDatabaseImpl : IDatabase
{

    private readonly SQLiteConnection dbConnection;

    public IDatabaseImpl()
    {
        dbConnection = DatabaseConnection.GetDatabase();
    }

    public List<T> GetEntities<T>() where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.Table<T>().ToList();
    }

    public int SaveEntities<T>(List<T> items) where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.InsertAll(items);
    }
}
