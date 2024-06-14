using NoivaCiaApp.entity;

namespace NoivaCiaApp.mapper
{
    public interface IMapper<T, R> where R: Entity
    {
        public T MapToModel(R item);

        public R MapToEntity(T item);
    }
}

