//INICIALIZAÇAO E FINALIZAÇAO DO PROGRAMA 

Calendario cal = new Calendario();
Console.WriteLine(cal.Prox_date());
Console.WriteLine(cal.Prox_date(cal.Prox_date()));

GerenciadorEspaco gerenciadorEspaco = new GerenciadorEspaco();

Espaco espaco = gerenciadorEspaco.ReservarEspaco(60);