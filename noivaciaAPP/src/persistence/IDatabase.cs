using NoivaCiaApp.entity;

namespace NoivaCiaApp.persistence
{
    public interface IDatabase
    {
        public List<T> GetEntities<T>() where T: Entity, new();
    }
}
