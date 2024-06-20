using System.CodeDom;
using NoivaCiaApp.mapper;

class FestaMapper : IMapper<Casamento, FestaEntity>
{
    GerenciadorEspaco gerencia = new GerenciadorEspaco();
    public FestaEntity MapToEntity(Casamento casamento)
    {
        return new FestaEntity(){
            Id = casamento.Id,
            FkEspaco  = casamento.EspacoCasamento.Id,
            Categoria = (int)casamento.TipoCasamento,
            TipoEvento  = (int)casamento.TipoCasamento,
            Valor = casamento.PrecoFinalCasamento,
            Data = casamento.EspacoCasamento.Data,
        };
    }
    Espaco espaco;
    public Casamento MapToModel(FestaEntity casamento)
    {
        //retornar espaço pelo id do espaço
        
        GerenciadorEspaco gerencia = new GerenciadorEspaco();
        foreach(Espaco a in gerencia.Lista_espacos){
            if(a.Id == casamento.Id){
                espaco =new Espaco(a.Nome, a.CapacidadeMax, a.Valor, a.Tipo);
                return new Casamento(espaco, (EventoTipoEnum)casamento.TipoEvento);
            }
            else{
                return new Casamento(espaco, (EventoTipoEnum)casamento.TipoEvento);
            }
            
        }
        return new Casamento(espaco, (EventoTipoEnum)casamento.TipoEvento);
    }
}