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
        private readonly IDatabase database;

        public FestaRepository(
            IMapper<Festa, FestaEntity> mapper,
            IMapper<Espaco, EspacoEntity> espacoMapper,
            IDatabase database
        )
        {
            this.mapper = mapper;
            this.espacoMapper = espacoMapper;
            this.database = database;
        }

        public List<Casamento> GetCasamentoPorTipo(TipoEventoEnum tipo)
        {
            try
            {
                return database
                    .GetEntities<FestaEntity>()
                    .Where(item => item.Categoria == (int)tipo)
                    .Select(item => mapper?.MapToModel(item))
                    .OfType<Casamento>()
                    .ToList();
            }
            catch
            {
                return new List<Casamento>();
            }
        }
        public bool SaveFesta(Festa festa, float valorTotal)
        {
            var entity = mapper.MapToEntity(festa);
            entity.Valor = valorTotal;
            entity.Data = festa.Espaco.Data;

            database.SaveEntity(entity);

            List<ItemsFestaEntity> items = festa.Items.Select(item =>
                new ItemsFestaEntity()
                {
                    Fk_Festa = entity.Id,
                    Fk_Item = item.Id,
                    Quantidade = item.QuantidadeDoItem
                }
            ).ToList();
            database.SaveEntities(items);

            return true;
        }

        public bool DeleteFesta(int id)
        {
            return database.DeleteById<Festa>(id) > 0;
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
                        if(espacoEntity != null){
                            Espaco espaco = espacoMapper.MapToModel(espacoEntity);
                            if(espaco != null){
                               f.Espaco = espaco;
                            }
                        }
                        
                        return f;
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
                return new List<Festa>();
            }
        }
    }
}
