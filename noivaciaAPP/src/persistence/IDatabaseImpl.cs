using System.Data.Entity;
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

    public int DeleteAllEntities<T>() where T : Entity, new()
    {
        return dbConnection.DeleteAll<T>();
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

    public List<T> RunQuery<T>(string query) where T : Entity, new() => dbConnection.FindWithQuery<List<T>>(query);

    public int SaveAllEntities<T>(List<T> entities) where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.InsertAll(entities);
    }

    public int SaveEntity<T>(T entity) where T : Entity, new()
    {
        dbConnection.CreateTable<T>();
        return dbConnection.Insert(entity);
    }
}
