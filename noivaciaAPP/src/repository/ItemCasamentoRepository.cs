using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class ItemCasamentoRepository
    {

        private readonly IMapper<ItemCasamento, ItemFestaEntity> mapper;
        private readonly IDatabase database;

        public ItemCasamentoRepository(
            IMapper<ItemCasamento, ItemFestaEntity> mapper,
            IDatabase database
        )
        {
            this.mapper = mapper;
            this.database = database;

            PopulateDbIfEmpty();
        }

        private void PopulateDbIfEmpty()
        {
            int itemsDatabaseCount = database.GetEntities<ItemFestaEntity>().Count;
            int items = ItemsCasamento().Count;

            if (items != itemsDatabaseCount)
            {
                database.DeleteAllEntities<ItemFestaEntity>();

                var entities = ItemsCasamento()
                    .Select(mapper.MapToEntity)
                    .ToList();

                database.SaveAllEntities(entities);
            }
        }

        public List<ItemCasamento> GetItemCasamentoPorTipo(
            ItemTipoEnum tipo,
            CasamentoTipoEnum casamentoTipo
        )
        {
            try
            {
                return database
                    .GetEntities<ItemFestaEntity>()
                    .Where(item => item.TipoItem == (int)tipo && item.TipoCasamento == (int)casamentoTipo)
                    .Select(item => mapper?.MapToModel(item))
                    .OfType<ItemCasamento>()
                    .ToList();
            }
            catch
            {
                return new List<ItemCasamento>();
            }
        }

        private List<ItemCasamento> ItemsCasamento()
        {
            return new List<ItemCasamento>(){
                new ItemCasamento("Itens de Mesa", 50, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO, TipoServico.ITENS_DE_MESAS),
                new ItemCasamento("Decoração", 50, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO, TipoServico.DECORACAO),
                new ItemCasamento("BoloCasamento", 10, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO, TipoServico.BOLO),
                new ItemCasamento("Música", 20, CasamentoTipoEnum.STANDART, ItemTipoEnum.BASICO, TipoServico.MUSICA),
                new ItemCasamento("Coxinha", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
                new ItemCasamento("Kibe", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
                new ItemCasamento("Empadinha", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
                new ItemCasamento("Pão de Queijo", 40, CasamentoTipoEnum.STANDART, ItemTipoEnum.COMIDA),
                new ItemCasamento("Água Sem Gás (1.5 L)", 5, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Suco(1 L)", 7, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Refrigerante (2 L)", 8, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Cerveja Comum (600 ml)", 20, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Espumante Nacional (750 ml)", 80, CasamentoTipoEnum.STANDART, ItemTipoEnum.BEBIDA),

                new ItemCasamento("Itens de Mesa", 75, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO , TipoServico.ITENS_DE_MESAS),
                new ItemCasamento("Decoração", 75, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO, TipoServico.DECORACAO),
                new ItemCasamento("BoloCasamento", 15, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO, TipoServico.BOLO),
                new ItemCasamento("Música", 25, CasamentoTipoEnum.LUXO, ItemTipoEnum.BASICO, TipoServico.MUSICA),
                new ItemCasamento("Croquete de Carne Seca", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
                new ItemCasamento("Barquetes Legumes", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
                new ItemCasamento("Empadinha Gourmet", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
                new ItemCasamento("Cestinha Bacalhau", 48, CasamentoTipoEnum.LUXO, ItemTipoEnum.COMIDA),
                new ItemCasamento("Água Sem Gás (1.5 L)", 5, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Suco(1 L)", 7, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Refrigerante (2 L)", 8, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Cerveja Comum (600 ml)", 20, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Cerveja Artesanal (600 ml)", 30, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Espumante Nacional (750 ml)", 80, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Espumante Importado (750 ml)", 140, CasamentoTipoEnum.LUXO, ItemTipoEnum.BEBIDA),

                new ItemCasamento("Itens de Mesa", 100, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO , TipoServico.ITENS_DE_MESAS),
                new ItemCasamento("Decoração", 100, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO, TipoServico.DECORACAO),
                new ItemCasamento("BoloCasamento", 20, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO, TipoServico.BOLO),
                new ItemCasamento("Música", 30, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BASICO, TipoServico.MUSICA),
                new ItemCasamento("Canapé", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
                new ItemCasamento("Tartine", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
                new ItemCasamento("Bruschetta", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
                new ItemCasamento("Espetinho carprese", 60, CasamentoTipoEnum.PREMIER, ItemTipoEnum.COMIDA),
                new ItemCasamento("Água Sem Gás (1.5 L)", 5, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Suco(1 L)", 7, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Refrigerante (2 L)", 8, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Cerveja Comum (600 ml)", 20, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Cerveja Artesanal (600 ml)", 30, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Espumante Nacional (750 ml)", 80, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
                new ItemCasamento("Espumante Importado (750 ml)", 140, CasamentoTipoEnum.PREMIER, ItemTipoEnum.BEBIDA),
            };
        }
    }
}
