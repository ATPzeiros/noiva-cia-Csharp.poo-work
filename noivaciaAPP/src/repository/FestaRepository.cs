using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class FestaRepository
    {

        private readonly IMapper<Festa, FestaEntity> mapper;
        private readonly IMapper<Espaco, EspacoEntity> espacoMapper;
        private readonly IMapper<ItemFesta, ItemFestaEntity> itemMapper;
        private readonly IDatabase database;

        public FestaRepository(
            IMapper<Festa, FestaEntity> mapper,
            IMapper<Espaco, EspacoEntity> espacoMapper,
            IMapper<ItemFesta, ItemFestaEntity> itemMapper,
            IDatabase database
        )
        {
            this.mapper = mapper;
            this.espacoMapper = espacoMapper;
            this.itemMapper = itemMapper;
            this.database = database;
        }

        public bool SaveFesta(Festa festa, float valorTotal)
        {
            var entity = mapper.MapToEntity(festa);
            entity.Valor = valorTotal;
            entity.Data = festa?.Espaco?.Data;

            database.SaveEntity(entity);

            List<ItemsFestaEntity> items = festa?.Items.Select(item =>
                new ItemsFestaEntity()
                {
                    Fk_Festa = entity.Id,
                    Fk_Item = item.Id,
                    Quantidade = item.QuantidadeDoItem
                }
            ).ToList() ?? new List<ItemsFestaEntity>();
            database.SaveEntities(items);

            return true;
        }

        public bool DeleteFesta(int id)
        {
            return database.DeleteById<FestaEntity>(id) > 0;
        }

        public List<Festa> GetAllFestas()
        {
            try
            {
                return database
                    .GetEntities<FestaEntity>()
                    .Select(festa =>
                    {
                        EspacoEntity? espacoEntity = database.GetEntities<EspacoEntity>().Find(item => item.Id == festa.FkEspaco);
                        var f = mapper.MapToModel(festa);
                        if (espacoEntity != null)
                        {
                            Espaco espaco = espacoMapper.MapToModel(espacoEntity);
                            if (espaco != null)
                            {
                                f.Espaco = espaco;
                            }
                        }

                        return f;
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                return new List<Festa>();
            }
        }

        public List<ItemFesta> GetItemsDaFesta(int IdFesta)
        {
            return database
            .GetEntities<ItemsFestaEntity>()
            .Where(item => item.Fk_Festa == IdFesta)
            .Select(item =>
            {
                var i = database.GetEntities<ItemFestaEntity>().Where(i => i.Id ==item.Fk_Item).First();
                var itemFesta = itemMapper.MapToModel(i);
                itemFesta.QuantidadeDoItem = item.Quantidade;
                return itemFesta;
            }).ToList();
        }
    }
}
