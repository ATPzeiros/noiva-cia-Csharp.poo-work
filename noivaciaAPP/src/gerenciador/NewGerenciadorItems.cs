using NoivaCiaApp.model;
using NoivaCiaApp.repository;

namespace noivaCiaApp.gerenciador
{
    class NewGerenciadorItems
    {
        private readonly ItemRepository repository;

        public NewGerenciadorItems(ItemRepository repository)
        {
            this.repository = repository;
        }

        public List<Item> GetItemsServicoBasico(
            ItemTipoEnum tipo,
            CategoriaFesta categoria,
            TipoFesta tipoCasamento
        )
        {
            List<Item> items = repository.GetItemPorTipo(tipo, tipoCasamento);

            if (categoria == CategoriaFesta.CASAMENTO)
            {
                return items;
            }
            else if (categoria == CategoriaFesta.FORMATURA)
            {
                return items.Where(item => item.TipoServico != TipoServico.BOLO).ToList();
            }
            else if (categoria == CategoriaFesta.FESTA_DE_EMPRESA)
            {
                return items.Where(item =>
                    item.TipoServico != TipoServico.BOLO &&
                    item.TipoServico != TipoServico.ITENS_DE_MESAS &&
                    item.TipoServico != TipoServico.DECORACAO
                ).ToList();
            }
            else if (categoria == CategoriaFesta.FESTA_DE_ANIVERSARIO)
            {
                return items.Where(item => item.TipoFesta == TipoFesta.STANDART).ToList();
            }
            else
            {
                return new List<Item>();
            }
        }

        public List<Item> GetItemsFestaPorTipo(
            ItemTipoEnum tipo,
            TipoFesta categoria
        ){
            return repository.GetItemPorTipo(tipo, categoria);
        }
    }
}