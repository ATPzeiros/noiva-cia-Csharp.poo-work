interface IMapper<T, R>{
    public T MapToModel(R item);

    public R MapToEntity(T item);
}
