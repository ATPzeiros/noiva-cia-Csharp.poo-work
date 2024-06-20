using System.Media;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using SQLitePCL;

namespace NoivaCiaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            string[] primeiroMenu = { "Marcar Evento", "Ver Evento", "Excluir Evento", "SAIR" };
            string[] subMenuVerCasamentos = { "Ver Eventos", "Voltar" };
            string[] subMenuExcluirCasamentos = { "Por ID", "Voltar" };
            string[] menuAtual = primeiroMenu;
            string cabecalho = "Inicio";

            int subMenu = 0;
            int posicaoAtual = 0;
            int op = 1;
            ConsoleKeyInfo keyInfo;

            _ = new PopulateDatabase(database: new IDatabaseImpl(), mapper: new ItemCasamentoMapper(), espacoMapper: new EspacoMapper());

            do
            {
                Menu.MostrarMenu(menuAtual, posicaoAtual, cabecalho);
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (posicaoAtual + 1 < menuAtual.Length)
                    {
                        posicaoAtual++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (posicaoAtual - 1 >= 0)
                    {
                        posicaoAtual--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (subMenu == 0)
                    {
                        if (posicaoAtual == 0)
                        {
                            MarcarFestaView.MostrarView();
                        }
                        else if (posicaoAtual == 1)
                        {
                            menuAtual = subMenuVerCasamentos;
                            subMenu = 1;
                            cabecalho = "Ver Casamentos";
                            posicaoAtual = 0;
                        }
                        else if (posicaoAtual == 2)
                        {
                            menuAtual = subMenuExcluirCasamentos;
                            subMenu = 2;
                            cabecalho = "Exlcuir Casamentos";

                            posicaoAtual = 0;
                        }
                        else if (posicaoAtual == 3)
                        {
                            Console.WriteLine("Fechando o sistema...");
                            SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory() + "/src/sound/win-shutdown.wav");
                            player.PlaySync();
                            op = -1;
                        }
                    }
                    else if (subMenu == 1)
                    {

                        if (posicaoAtual == 0)
                        {
                            GerenciadorEvento GE = new GerenciadorEvento(
                                repository: RepositoryInjector.CreateFestaRepository(),
                                relatorio: RelatorioInjection.GenerateFestaRelatorio()
                            );
                            List<Festa> festas = GE.ListaDeFestas();

                            if (festas.Count != 0)
                            {
                                Festa festa = InputReader.SelecionarDaLista("Selecione a festa", festas);
                                GE.GerarResumoDetalhado(festa);
                            }
                            else
                            {
                                Console.WriteLine("Nenhum evento cadastrado.\nPressione qualquer tecla...");
                            }
                            Console.ReadKey();
                        }

                        else if (posicaoAtual == 1)
                        {
                            menuAtual = primeiroMenu;
                            subMenu = 0;
                            cabecalho = "Inicio";
                            posicaoAtual = 0;
                        }
                    }
                    else if (subMenu == 2)
                    {
                        if (posicaoAtual == 0)
                        {
                            GerenciadorEvento GE = new GerenciadorEvento(
                                repository: RepositoryInjector.CreateFestaRepository(),
                                relatorio: RelatorioInjection.GenerateFestaRelatorio()
                            );
                            List<Festa> festas = GE.ListaDeFestas();

                            if (festas.Count != 0)
                            {
                                Festa festa = InputReader.SelecionarDaLista("Selecione a festa", festas);
                                if (GE.ExcluirEventoPorId(festa.Id))
                                {
                                    Console.WriteLine("Deledado com sucesso!\nPressione qualquer tecla...");
                                }
                                else
                                {
                                    Console.WriteLine("Tivemos um erro. Tente novamente.");
                                }
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Nenhum evento cadastrado.\nPressione qualquer tecla...");
                            }

                            Console.ReadKey();
                        }

                        else if (posicaoAtual == 1)
                        {
                            menuAtual = primeiroMenu;
                            subMenu = 0;
                            cabecalho = "Inicio";
                            posicaoAtual = 0;
                        }
                    }
                }
            } while (op != -1);
        }
    }
}
