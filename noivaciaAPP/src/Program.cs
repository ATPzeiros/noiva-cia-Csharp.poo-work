﻿using System.Media;
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
            string[] subMenuVerCasamentos = { "Ver Evento Por Data", "Ver Evento Por Quantidade Convidados", "Voltar" };
            string[] subMenuExcluirCasamentos = { "Por Data", "Por Convidados", "Voltar" };
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
                            Festa festa = InputReader.SelecionarDaLista("Selecione a festa", GE.ListaDeFestas());
                            GE.GerarResumo(festa);
                        }

                        else if (posicaoAtual == 1)
                        {
                            Console.WriteLine("IMPLEMENTANDO");
                            Console.ReadKey();
                        }
                        else if (posicaoAtual == 2)
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
                            // GE.ListaDeFestas().ForEach(f => Console.WriteLine($"{f.Id}\t{f?.Espaco?.Nome}\t{f?.Date.ToShortDateString()}"));
                            // Console.WriteLine("Informe o id da festa: ");
                            Festa festa = InputReader.SelecionarDaLista("Selecione a festa", GE.ListaDeFestas());
                            GE.ExcluirEventoPorId(festa.Id);
                            Console.ReadKey();
                        }

                        else if (posicaoAtual == 1)
                        {
                            GerenciadorEvento gEvento = new(
                                repository: RepositoryInjector.CreateFestaRepository(),
                                relatorio: RelatorioInjection.GenerateFestaRelatorio()
                            );

                            Console.WriteLine("IMPLEMENTANDO");
                            Console.ReadKey();
                        }
                        else if (posicaoAtual == 2)
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
