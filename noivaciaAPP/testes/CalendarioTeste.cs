using System.Diagnostics;

class CalendarioTeste
{
    static Calendario calendario= new Calendario();

    public static void QuandoProxDate_DeveRetornarDataAtualCom30Dias(){
        //açao do teste
        var result = calendario.Prox_date();
        Console.WriteLine(result);
        //verificaçao teste
        Debug.Assert(result.DayOfWeek == DayOfWeek.Friday || result.DayOfWeek == DayOfWeek.Saturday);
    }
     public static void QuandoProxDate_DeveRetornarIntervaloMaiorQue30Dias(){
        //inicial
        var data_hoje = DateTime.Today;
        //açao do teste
        var result = calendario.Prox_date();
        Console.WriteLine(result);
        //verificaçao teste
        Debug.Assert((result - data_hoje).TotalDays >= 30);
    }
}