using System.Media;
using System.Net.NetworkInformation;




//INICIALIZAÇAO E FINALIZAÇAO DO PROGRAMA 


// Calendario cal = new Calendario();
// Console.WriteLine(cal.Prox_date());
// Console.WriteLine(cal.Prox_date(cal.Prox_date()));
// GerenciadorEspaco gerenciadorEspaco = new GerenciadorEspaco();
// Espaco espaco = gerenciadorEspaco.ReservarEspaco(60);

//CalendarioTeste.QuandoProxDate_DeveRetornarDataAtualCom30Dias();
//CalendarioTeste.QuandoProxDate_DeveRetornarIntervaloMaiorQue30Dias();

//var clientes = Database.GetClientes();

//Console.WriteLine(clientes.Rows[0]["email"]);

GerenciadorEspaco gerenciaEspaco = new GerenciadorEspaco();
GerenciadorDeItem gerenciaItem = new GerenciadorDeItem();
// int qtd = 50;
// Console.WriteLine(Casamento.EspacoCasamento.Nome);

// Console.WriteLine(Casamento.ValorTotalCasamento());


Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Green;

string [] primeiroMenu = {"Marcar Casamento","Ver Casamentos","Excluir Casamentos","SAIR"};
string [] subMenuVerCasamentos = {"Ver Casamentos Por Data","Ver Casamento Por Quantidade Convidados","Voltar"};
string [] subMenuExcluirCasamentos = {"Por Data","Por Convidados","Voltar"};
string[] menuAtual = primeiroMenu;
string cabecalho = "Inicio";

int subMenu = 0;
int posicaoAtual = 0;
int op = 1;
ConsoleKeyInfo keyInfo;

do 
{
    Menu.MostrarMenu(menuAtual,posicaoAtual, cabecalho);
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
                if(subMenu == 0){
                    if(posicaoAtual == 0){
                         GerenciadorCasamento.MarcarCasamento();
                    }
                    else if(posicaoAtual == 1 ){
                        menuAtual = subMenuVerCasamentos;
                        subMenu = 1;
                        cabecalho = "Ver Casamentos";
                        posicaoAtual = 0;
                    }
                     else if(posicaoAtual == 2){
                        menuAtual = subMenuExcluirCasamentos;
                        subMenu = 2;
                        cabecalho = "Exlcuir Casamentos";
                        posicaoAtual = 0;
                    }
                     else if(posicaoAtual == 3){
                        Console.WriteLine("Fechando o sistema...");
                        SoundPlayer player = new SoundPlayer(Directory.GetCurrentDirectory() + "/sound/win-shutdown.wav");
                        player.PlaySync();
                        op = -1;
                    }
                }
                else if( subMenu == 1){

                    if(posicaoAtual == 0){
                        Console.WriteLine("IMPLEMENTANDO");
                        Console.ReadKey();
                    }

                    else if(posicaoAtual == 1 ){
                        Console.WriteLine("IMPLEMENTANDO");
                        Console.ReadKey();
                    }
                     else if(posicaoAtual == 2){
                        menuAtual = primeiroMenu;
                        subMenu = 0;
                        cabecalho = "Inicio";
                        posicaoAtual=0;
                    }
                }
                else if( subMenu == 2 ){
                    if(posicaoAtual == 0){
                        Console.WriteLine("IMPLEMENTANDO");
                        Console.ReadKey();
                    }

                    else if(posicaoAtual == 1 ){
                        Console.WriteLine("IMPLEMENTANDO");
                        Console.ReadKey();
                    }
                    else if(posicaoAtual == 2){
                        menuAtual = primeiroMenu;
                        subMenu = 0;
                        cabecalho = "Inicio";
                        posicaoAtual = 0;
                    }
                }
            }
}while (op != -1);