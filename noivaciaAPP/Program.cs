//INICIALIZAÇAO E FINALIZAÇAO DO PROGRAMA 
// Calendario cal = new Calendario();
// Console.WriteLine(cal.Prox_date());
// Console.WriteLine(cal.Prox_date(cal.Prox_date()));
// GerenciadorEspaco gerenciadorEspaco = new GerenciadorEspaco();
// Espaco espaco = gerenciadorEspaco.ReservarEspaco(60);

//CalendarioTeste.QuandoProxDate_DeveRetornarDataAtualCom30Dias();
//CalendarioTeste.QuandoProxDate_DeveRetornarIntervaloMaiorQue30Dias();

var clientes = Database.GetClientes();

Console.WriteLine(clientes.Rows[0]["email"]);