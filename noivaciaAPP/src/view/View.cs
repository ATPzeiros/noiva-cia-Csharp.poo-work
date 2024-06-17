using Spectre.Console;

abstract class View
{
    abstract public string Cabecalho { get; }
    abstract public List<(string, NivelMenu)> Niveis { get; }

    abstract public void OnMenuSelected(NivelMenu menu);

    public void ShowMenu(Action<NivelMenu> action){
        Console.Clear();
        AnsiConsole.Write(
            new Rule("Festas&Cia")
            {
                Justification = Justify.Center
            }
        );

        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(Cabecalho)
                .PageSize(Niveis.Count)
                .AddChoices(Niveis.Select(nivel => nivel.Item1))
        );

        action(Niveis.Find(item => item.Item1 == option).Item2);
    }
}