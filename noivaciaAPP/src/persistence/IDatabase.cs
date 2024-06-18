using NoivaCiaApp.entity;

namespace NoivaCiaApp.persistence
{
    public interface IDatabase
    {
        public List<T> GetEntities<T>() where T: Entity, new();

        public int SaveEntities<T>(List<T> items) where T: Entity, new();
    }
}
