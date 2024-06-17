using Spectre.Console;

namespace NoivaCiaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            _ = new InicioView();

            // string[] primeiroMenu = { "Marcar Casamento", "Ver Casamentos", "Excluir Casamentos", "SAIR" };
            // string[] subMenuVerCasamentos = { "Ver Casamentos Por Data", "Ver Casamento Por Quantidade Convidados", "Voltar" };
            // string[] subMenuExcluirCasamentos = { "Por Data", "Por Convidados", "Voltar" };
            // string[] menuAtual = primeiroMenu;
            // string cabecalho = "Inicio";

            // int subMenu = 0;
            // int posicaoAtual = 0;
            // int op = 1;
            // ConsoleKeyInfo keyInfo;

            // do
            // {
            //     Menu.MostrarMenu(menuAtual, posicaoAtual, cabecalho);
            //     keyInfo = Console.ReadKey();
            //     if (keyInfo.Key == ConsoleKey.DownArrow)
            //     {
            //         if (posicaoAtual + 1 < menuAtual.Length)
            //         {
            //             posicaoAtual++;
            //         }
            //     }
            //     else if (keyInfo.Key == ConsoleKey.UpArrow)
            //     {
            //         if (posicaoAtual - 1 >= 0)
            //         {
            //             posicaoAtual--;
            //         }
            //     }
            //     else if (keyInfo.Key == ConsoleKey.Enter)
            //     {
            //         if (subMenu == 0)
            //         {
            //             if (posicaoAtual == 0)
            //             {
            //                 Console.WriteLine("INICIAR PROCESSO DE LOCACAO DE ESPACO (ESCOLHA DO ESPACO)");
            //                 NewGerenciadorEspaco gEspaco = new(
            //                     repository: RepositoryInjector.CreateEspacoRepository(),
            //                     calendario: new Calendario()
            //                 );

            //                 Console.WriteLine("Espaco para quantas pessoas?");
            //                 int qntPessoas = int.Parse(Console.ReadLine() ?? "0");
            //                 Locacao loc = gEspaco.SelecionarEspaco(qntPessoas);
            //                 Console.WriteLine("Espaco encontrado: " + loc.Espaco.Nome);
            //                 Console.WriteLine("Data: " + loc.Date.ToShortDateString());
            //                 Console.ReadKey();

            //                 Console.WriteLine("ESCOLHA A **CATEGORIA** DA SUA FESTA");
                            
            //                 Enum
            //                 .GetValues<CategoriaFesta>()
            //                 .ToList()
            //                 .ForEach(tipo => Console.WriteLine(tipo));

            //                 CategoriaFesta categoria = (CategoriaFesta)int.Parse(Console.ReadLine() ?? "0");

            //                 Console.ReadKey();

            //                 Console.WriteLine("ESCOLHA O **TIPO** DA SUA FESTA");
            //                 NewGerenciadorItems gItem = new(
            //                     repository: RepositoryInjector.CreateItemCasamentoRepository()
            //                 );

            //                 Enum
            //                 .GetValues<CasamentoTipoEnum>()
            //                 .Select((tipo, i) => new {index = i, item = tipo})
            //                 .ToList()
            //                 .ForEach(tipo => Console.WriteLine(tipo.index + " - " + tipo.item));

            //                 CasamentoTipoEnum tipo = (CasamentoTipoEnum)int.Parse(Console.ReadLine() ?? "0");

            //                 Console.WriteLine(tipo);
            //                 Console.WriteLine(categoria);

            //                 Console.ReadKey();

            //                 Console.WriteLine("ESCOLHA DOS ITEMS");
            //                 Console.WriteLine("ITEMS DE SERVICO BASICO OBRIGATORIOS PARA SUA FESTA:");
            //                 Console.WriteLine("===========");
            //                 var itemsBasico = gItem.GetItemsServicoBasico(ItemTipoEnum.BASICO, CategoriaFesta.CASAMENTO, CasamentoTipoEnum.LUXO);
            //                 Console.WriteLine("===========");

            //                 Console.WriteLine("\nITEMS DE SERVICO COMIDA:");
            //                 Console.WriteLine("===========");
            //                 var itemsComida = gItem.GetItemsFestaPorTipo(ItemTipoEnum.COMIDA, CasamentoTipoEnum.LUXO);
            //                 Console.WriteLine("===========");

            //                 Console.WriteLine("\nITEMS DE SERVICO BEBIDA:");
            //                 Console.WriteLine("===========");
            //                 var bebidas = gItem
            //                     .GetItemsFestaPorTipo(ItemTipoEnum.BEBIDA, CasamentoTipoEnum.LUXO)
            //                     .Select(item => {
            //                         Console.WriteLine("Selecione a quantidade de " + item.Name);
            //                         int qnt = int.Parse(Console.ReadLine() ?? "0");
            //                         Console.WriteLine($">>>>>>>>{qnt}");
            //                         return new ItemComQuantidade(Item: item , Quantidade: qnt);
            //                     }).ToList();

            //                 bebidas.ForEach(item => Console.WriteLine(item.Quantidade));
                            
            //                 Console.WriteLine("===========");
            //                 Console.ReadKey();

            //                 Console.WriteLine("\nREVISE A MARCAO DO EVENTO");
            //                 GerenciadorFesta gFesta = new(
            //                     repository: RepositoryInjector.CreateFestaRepository()
            //                 );
            //                 Festa festa = new(
            //                     TipoFesta: tipo,
            //                     Locacao: loc, 
            //                     ItemsObrigatorios: itemsBasico.Concat(itemsComida).ToList(), 
            //                     ItemsSelecionaveis: bebidas
            //                 );
                            
            //                 Console.WriteLine(gFesta.ResumoDaFesta(festa));
            //                 Console.ReadKey();
            //             }
            //             else if (posicaoAtual == 1)
            //             {
            //                 menuAtual = subMenuVerCasamentos;
            //                 subMenu = 1;
            //                 cabecalho = "Ver Casamentos";
            //                 posicaoAtual = 0;
            //             }
            //             else if (posicaoAtual == 2)
            //             {
            //                 menuAtual = subMenuExcluirCasamentos;
            //                 subMenu = 2;
            //                 cabecalho = "Exlcuir Casamentos";
            //                 posicaoAtual = 0;
            //             }
            //             else if (posicaoAtual == 3)
            //             {
            //                 Console.WriteLine("Fechando o sistema...");
            //                 SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory() + "/src/sound/win-shutdown.wav");
            //                 player.PlaySync();
            //                 op = -1;
            //             }
            //         }
            //         else if (subMenu == 1)
            //         {

            //             if (posicaoAtual == 0)
            //             {
            //                 Console.WriteLine("IMPLEMENTANDO");
            //                 Console.ReadKey();
            //             }

            //             else if (posicaoAtual == 1)
            //             {
            //                 Console.WriteLine("IMPLEMENTANDO");
            //                 Console.ReadKey();
            //             }
            //             else if (posicaoAtual == 2)
            //             {
            //                 menuAtual = primeiroMenu;
            //                 subMenu = 0;
            //                 cabecalho = "Inicio";
            //                 posicaoAtual = 0;
            //             }
            //         }
            //         else if (subMenu == 2)
            //         {
            //             if (posicaoAtual == 0)
            //             {
            //                 Console.WriteLine("IMPLEMENTANDO");
            //                 Console.ReadKey();
            //             }

            //             else if (posicaoAtual == 1)
            //             {
            //                 Console.WriteLine("IMPLEMENTANDO");
            //                 Console.ReadKey();
            //             }
            //             else if (posicaoAtual == 2)
            //             {
            //                 menuAtual = primeiroMenu;
            //                 subMenu = 0;
            //                 cabecalho = "Inicio";
            //                 posicaoAtual = 0;
            //             }
            //         }
            //     }
            // } while (op != -1);
        }
    }
}
