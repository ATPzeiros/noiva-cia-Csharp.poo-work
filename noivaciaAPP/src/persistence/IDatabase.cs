using NoivaCiaApp.entity;

namespace NoivaCiaApp.persistence
{
    public interface IDatabase
    {
        public List<T> GetEntities<T>() where T: Entity, new();
        
        public T GetEntity<T>() where T: Entity, new();

        public int SaveEntities<T>(List<T> items) where T: Entity, new();

        public int SaveEntity<T>(T item) where T: Entity, new();

        public int DeleteById<T>(int id) where T: Entity, new();
    }
}
