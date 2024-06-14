using NoivaCiaApp.entity;
using NoivaCiaApp.model;

namespace NoivaCiaApp.mapper
{
    public interface IMapper<T, R> where T: Model where R: Entity
    {
        public T MapToModel(R item);

        public R MapToEntity(T item);
    }
}

