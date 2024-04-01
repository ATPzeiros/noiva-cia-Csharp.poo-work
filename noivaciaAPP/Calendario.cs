class Calendario{
    private DateTime Verify_fridayORsaturday(DateTime date){
        while(true){
            if(date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday){
                break;
            }
            date = date.AddDays(1);
        }
        return date;
    }
    public DateTime Prox_date(){
        DateTime date = DateTime.Today.AddDays(30);
        return Verify_fridayORsaturday(date);
    } 
    public DateTime Prox_date(DateTime date){
        date = date.AddDays(1);
        return Verify_fridayORsaturday(date);
    }
}