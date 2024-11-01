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

    public int DeleteById<T>(int id) where T : Entity, new()
    {
        return dbConnection.Delete<T>(id);
    }

    public List<T> GetEntities<T>() where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.Table<T>().ToList();
    }

    public T GetEntity<T>() where T : Entity, new()
    {
        return dbConnection.Table<T>().First();
    }

    public int SaveEntities<T>(List<T> items) where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.InsertAll(items);
    }

    public int SaveEntity<T>(T item) where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.Insert(item);
    }
    
}
