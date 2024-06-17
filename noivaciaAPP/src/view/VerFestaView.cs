
using NoivaCiaApp.model;
using Spectre.Console;

class VerFestaView : View
{
    public override string Cabecalho => "Ver festas";

    public override List<(string, NivelMenu)> Niveis => new(){
        ("Ver Festa Por Data", NivelMenu.VER_FESTA_POR_DATA),
        ("Ver todas as festas", NivelMenu.VER_TODAS_FESTAS),
        ("Voltar", NivelMenu.VOLTAR)
    };

    public VerFestaView()
    {
        ShowMenu(action: (menu) => OnMenuSelected(menu));
    }

    public override void OnMenuSelected(NivelMenu menu)
    {
        if (menu == NivelMenu.VER_FESTA_POR_DATA)
        {
            VerFestaController controller = new VerFestaController(
                repository: RepositoryInjector.CreateFestaRepository()
            );

            MostrarFestas(controller.BuscarFestas());
        }
        else if (menu == NivelMenu.VER_TODAS_FESTAS)
        {

        }
    }

    private void MostrarFestas(Dictionary<DateTime, List<Festa>> festasAgrupadas)
    {
        foreach (var item in festasAgrupadas)
        {
            Console.WriteLine($"DATA: {item.Key.ToShortDateString()}");

            var table = new Table();

            table.AddColumn("ID");
            table.AddColumn("NAME");
            table.AddColumn("TIPO");
            table.AddColumn("CATEGORIA");
            table.AddColumn("CONVIDADOS");

            AnsiConsole.Live(table)
                .Start(ctx =>
                {
                    foreach (var f in item.Value)
                    {
                        table.AddRow(
                            $"{f.Id}", "Nome aqui", 
                            $"{f?.TipoFesta ?? 0}", 
                            $"{f?.CategoriaFesta ?? 0}", 
                            $"{f?.QntConvidados ?? 0}"
                        );
                    };
                });


        }
        Console.ReadKey();
        // festasAgrupadas.ForEach(grupo => {
        //     Console.WriteLine(grupo.Key?.ToShortDateString());

        //     foreach (var festas in grupo)
        //     {
        //         festas.ForEach(festa => Console.WriteLine("id: " + festa.Id));
        //     }
        // });
    }

}