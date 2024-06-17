using System.Security.Cryptography.X509Certificates;
using NoivaCiaApp.model;
using Spectre.Console;

class InicioView: View
{
    public override string Cabecalho => "Inicio";

    public override List<(string, NivelMenu)> Niveis => new(){
        ("Marcar Festa", NivelMenu.MARCAR_FESTA),
        ("Ver Festas", NivelMenu.VER_FESTA),
        ("Excluir Festa", NivelMenu.EXCLUIR_FESTA),
        ("SAIR", NivelMenu.SAIR)
    };

    public InicioView(){
        ShowMenu((menu) => OnMenuSelected(menu));
    }

    public override void OnMenuSelected(NivelMenu menu){
        if(menu == NivelMenu.MARCAR_FESTA){
            FestaController controller = new (
                gEspaco: GerenciadorInjection.GerenciadorEspaco(),
                gItem: GerenciadorInjection.GerenciadorDeItem(),
                gFesta: GerenciadorInjection.GerenciadorDeFesta()
            );

            controller.AtualizarQntPessoas(SelecionarQuantidadePessoas());
            controller.AtualizarTipoFesta(EscolherTipo());
            controller.AtualizarCategoria(EscolherCategoria());
            controller.AtualizarBebidas(SelecionaQuantidadeBebidas(controller.GetItemsBebida()));
            controller.ConstruirFesta();

            MostrarResumoDaFesta(controller.Festa);
            if(ConfirmarFesta()){
                controller.FazerReserva();
                Console.WriteLine("Reserva feita.");
            }
        } else if(menu == NivelMenu.VER_FESTA){
            _ = new VerFestaView();
        } else if(menu == NivelMenu.EXCLUIR_FESTA){

        } else if(menu == NivelMenu.SAIR){
            Environment.Exit(0);
        }
    }

    private int SelecionarQuantidadePessoas(){
        return AnsiConsole.Prompt(
            new TextPrompt<int>($"A reservas é para quantos integrantes?").PromptStyle("green")
        );
    }
    

    private CategoriaFesta EscolherCategoria(){
        var categorias = Enum.GetValues<CategoriaFesta>();

        return AnsiConsole.Prompt(
            new SelectionPrompt<CategoriaFesta>()
                .Title("Escolha a categoria da festa")
                .PageSize(categorias.Length)
                .AddChoices(categorias)
        );
    }

    private TipoFesta EscolherTipo(){
        var tipos = Enum.GetValues<TipoFesta>();
        return AnsiConsole.Prompt(
            new SelectionPrompt<TipoFesta>()
                .Title("Escolha o tipo de festa")
                .PageSize(tipos.Length)
                .AddChoices(tipos)
        );
    }

    private List<ItemComQuantidade> SelecionaQuantidadeBebidas(List<Item> bebidas){
        return bebidas
            .Select(item => {
                int qnt = AnsiConsole.Prompt(
                    new TextPrompt<int>($"Quantos itens de [green]{item.Name}[/] deseja?")
                        .PromptStyle("green"));

                return new ItemComQuantidade(Item: item , Quantidade: qnt);
            })
            .ToList();
    }

    public void MostrarResumoDaFesta(Festa festa){
        AnsiConsole.Clear();
        float precoEspaco = festa?.Espaco?.Valor ?? 0F;
        float precoServicoBasico = festa?.ItemsObrigatorios.Where(item => item.TipoServico != null).Sum(item => item.Price) ?? 0F;
        float precoServicoComida = festa?.ItemsObrigatorios.Where(item => item.TipoItem == ItemTipoEnum.COMIDA).Sum(item => item.Price) ?? 0F;
        float precoServicoBebida = festa?.ItemsSelecionaveis.Where(item => item.TipoItem == ItemTipoEnum.BEBIDA).Sum(item => item.Price * item.Quantidade) ?? 0f;
        float valorFinal = precoEspaco + precoServicoBasico + precoServicoComida + precoServicoBebida;

        AnsiConsole.Write(new Rule("DATA & ESPAÇO"));
        AnsiConsole.Markup($"Espaco reservado: \t\t[bold yellow]{festa?.Espaco?.Nome}[/]\n");
        AnsiConsole.Markup($"Capacidade maxima: \t\t[bold yellow]{festa?.Espaco?.CapacidadeMax}[/]\n");
        AnsiConsole.Markup($"Quantidade de convidados: \t[bold yellow]{festa?.QntConvidados}[/]\n");
        AnsiConsole.Markup($"Data da festa: \t\t\t[bold yellow]{festa?.Date?.ToShortDateString()}[/] ({festa?.Date?.DayOfWeek}).\n");
        AnsiConsole.Write(new Rule($"R$ {precoEspaco}"){Justification = Justify.Right});

        var table = new Table();
        var sum = 0f;

        AnsiConsole.Live(table)
        .Start(ctx => 
        {
            table.AddColumn("Nome");
            table.AddColumn("Quantidade");
            table.AddColumn("Preco unitario");
            table.AddColumn(new TableColumn("Preço Final").Footer($"{sum}"));
            ctx.Refresh();
            Thread.Sleep(1000);

            festa?
                .ItemsSelecionaveis
                .ToList()
                .ForEach(item => {
                    table.AddRow(item.Name, item.Quantidade.ToString(), $"R$ {item.Price}" ,$"R$ {item.Quantidade * item.Price}");
                    sum += item.Quantidade * item.Price;
                    ctx.Refresh();
                    Thread.Sleep(500);
                });
            
            ctx.Refresh();
            table.AddRow("", "", "", $"R$ {precoServicoBebida}");
        });
    }

    public bool ConfirmarFesta() {
        return AnsiConsole.Confirm("Confirmar reserva da festa?");
    }
}