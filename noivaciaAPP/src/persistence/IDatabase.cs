using NoivaCiaApp.entity;

namespace NoivaCiaApp.persistence
{
    public interface IDatabase
    {
        public List<T> GetEntities<T>() where T: Entity, new();

        public int SaveEntity<T>(T entity) where T: Entity, new();

        public int SaveAllEntities<T>(List<T> entities) where T: Entity, new();

        public int DeleteAllEntities<T>() where T: Entity, new();

        public int DeleteById<T>(int id) where T: Entity, new();

        public List<T> RunQuery<T>(string query) where T: Entity, new();
    }
}
