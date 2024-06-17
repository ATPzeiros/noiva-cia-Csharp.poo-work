using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using NoivaCiaApp.persistence;

namespace NoivaCiaApp.repository
{
    public class ItemRepository
    {

        private readonly IMapper<Item, ItemEntity> mapper;
        private readonly IDatabase database;

        public ItemRepository(
            IMapper<Item, ItemEntity> mapper,
            IDatabase database
        )
        {
            this.mapper = mapper;
            this.database = database;

            PopulateDbIfEmpty();
        }

        private void PopulateDbIfEmpty()
        {
            int itemsDatabaseCount = database.GetEntities<ItemEntity>().Count;
            int items = ItemsCasamento().Count;

            if (items != itemsDatabaseCount)
            {
                database.DeleteAllEntities<ItemEntity>();

                var entities = ItemsCasamento()
                    .Select(mapper.MapToEntity)
                    .ToList();

                database.SaveAllEntities(entities);
            }
        }

        public List<Item> GetItemPorTipo(
            ItemTipoEnum tipo,
            TipoFesta casamentoTipo
        )
        {
            try
            {
                return database
                    .GetEntities<ItemEntity>()
                    .Where(item => item.TipoItem == (int)tipo && item.TipoFesta == (int)casamentoTipo)
                    .Select(item => mapper?.MapToModel(item))
                    .OfType<Item>()
                    .ToList();
            }
            catch
            {
                return new List<Item>();
            }
        }

        private List<Item> ItemsCasamento()
        {
            return new List<Item>(){
                new Item("Itens de Mesa", 50, TipoFesta.STANDART, ItemTipoEnum.BASICO, TipoServico.ITENS_DE_MESAS),
                new Item("Decoração", 50, TipoFesta.STANDART, ItemTipoEnum.BASICO, TipoServico.DECORACAO),
                new Item("BoloCasamento", 10, TipoFesta.STANDART, ItemTipoEnum.BASICO, TipoServico.BOLO),
                new Item("Música", 20, TipoFesta.STANDART, ItemTipoEnum.BASICO, TipoServico.MUSICA),
                new Item("Coxinha", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
                new Item("Kibe", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
                new Item("Empadinha", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
                new Item("Pão de Queijo", 40, TipoFesta.STANDART, ItemTipoEnum.COMIDA),
                new Item("Água Sem Gás (1.5 L)", 5, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
                new Item("Suco(1 L)", 7, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
                new Item("Refrigerante (2 L)", 8, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
                new Item("Cerveja Comum (600 ml)", 20, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),
                new Item("Espumante Nacional (750 ml)", 80, TipoFesta.STANDART, ItemTipoEnum.BEBIDA),

                new Item("Itens de Mesa", 75, TipoFesta.LUXO, ItemTipoEnum.BASICO , TipoServico.ITENS_DE_MESAS),
                new Item("Decoração", 75, TipoFesta.LUXO, ItemTipoEnum.BASICO, TipoServico.DECORACAO),
                new Item("BoloCasamento", 15, TipoFesta.LUXO, ItemTipoEnum.BASICO, TipoServico.BOLO),
                new Item("Música", 25, TipoFesta.LUXO, ItemTipoEnum.BASICO, TipoServico.MUSICA),
                new Item("Croquete de Carne Seca", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
                new Item("Barquetes Legumes", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
                new Item("Empadinha Gourmet", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
                new Item("Cestinha Bacalhau", 48, TipoFesta.LUXO, ItemTipoEnum.COMIDA),
                new Item("Água Sem Gás (1.5 L)", 5, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
                new Item("Suco(1 L)", 7, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
                new Item("Refrigerante (2 L)", 8, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
                new Item("Cerveja Comum (600 ml)", 20, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
                new Item("Cerveja Artesanal (600 ml)", 30, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
                new Item("Espumante Nacional (750 ml)", 80, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),
                new Item("Espumante Importado (750 ml)", 140, TipoFesta.LUXO, ItemTipoEnum.BEBIDA),

                new Item("Itens de Mesa", 100, TipoFesta.PREMIER, ItemTipoEnum.BASICO , TipoServico.ITENS_DE_MESAS),
                new Item("Decoração", 100, TipoFesta.PREMIER, ItemTipoEnum.BASICO, TipoServico.DECORACAO),
                new Item("BoloCasamento", 20, TipoFesta.PREMIER, ItemTipoEnum.BASICO, TipoServico.BOLO),
                new Item("Música", 30, TipoFesta.PREMIER, ItemTipoEnum.BASICO, TipoServico.MUSICA),
                new Item("Canapé", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
                new Item("Tartine", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
                new Item("Bruschetta", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
                new Item("Espetinho carprese", 60, TipoFesta.PREMIER, ItemTipoEnum.COMIDA),
                new Item("Água Sem Gás (1.5 L)", 5, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
                new Item("Suco(1 L)", 7, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
                new Item("Refrigerante (2 L)", 8, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
                new Item("Cerveja Comum (600 ml)", 20, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
                new Item("Cerveja Artesanal (600 ml)", 30, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
                new Item("Espumante Nacional (750 ml)", 80, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
                new Item("Espumante Importado (750 ml)", 140, TipoFesta.PREMIER, ItemTipoEnum.BEBIDA),
            };
        }
    }
}
