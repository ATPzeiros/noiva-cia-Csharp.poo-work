public class Calendario{

    //Objetivo: Recebe uma data qualquer que será definida ao longo do sistema ->
    //  Logo em seguida faz uma verificaçao para saber se o dia que receber é igual a sexta ou sabado ->
    //      True --> Ele quebra o loop e retorna a data recebida.
    //      False --> Pega a data que foi recebida e acrescenta 1 dia a ela .
    //Retorno: Uma data correspondente a um sexta ou sabado.
    private DateTime FindNext_fridayORsaturday(DateTime date){
        while(true){
            if(date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday){
                break;
            }
            date = date.AddDays(1);
        }
        return date;
    }

    //Objetivo: Pegar a data atual onde ela for chamada e somar 30 dias a ela, apos isso chamar a funçao FindNext_fridayORsaturday.
    //Retorno: Uma data onde será sexta ou sabado.
    public DateTime Prox_date(){
        DateTime date = DateTime.Today.AddDays(30);
        return FindNext_fridayORsaturday(date);
    } 

    //Objetivo: Recebe uma data, acrescenta 1 dia nela e chama a funçao FindNext_fridayORsaturday.
    //Retorno: Uma data onde será sexta ou sabado.
    public DateTime Prox_date(DateTime date){
        date = date.AddDays(1);
        return FindNext_fridayORsaturday(date);
    }
}