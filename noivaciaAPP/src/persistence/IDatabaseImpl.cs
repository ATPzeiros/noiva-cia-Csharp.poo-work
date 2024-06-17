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
        return dbConnection.Table<T>().ToList();
    }
}
