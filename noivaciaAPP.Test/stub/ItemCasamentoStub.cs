using NoivaCiaApp.entity;
using NoivaCiaApp.model;

static class ItemCasamentoStub {
    public static ItemCasamento GenerateItemCasamento(){
        return new ItemCasamento(
                Name: "Nome 123", 
                Value: 0f, 
                TipoCasamento: CasamentoTipoEnum.STANDART, 
                TipoItem: ItemTipoEnum.COMIDA
            );
    }

    public static ItemFestaEntity GenerateItemCasamentoEntity(){
        return new ItemFestaEntity()
            {
                Name = "Nome 123",
                Value = 0f,
                TipoCasamento = (int)CasamentoTipoEnum.STANDART,
                TipoItem = (int)ItemTipoEnum.COMIDA
            };
    }
}