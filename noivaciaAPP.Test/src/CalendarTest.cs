namespace noivaciaAPP.Test.calendar
{
    class CalendarTest
    {
        static readonly Calendario calendario = new();

        [Test]
        public static void QuandoProxDate_DeveRetornarDataAtualCom30Dias()
        {
            //açao do teste
            var result = calendario.Prox_date();
            //verificaçao teste
            Assert.That(result.DayOfWeek == DayOfWeek.Friday || result.DayOfWeek == DayOfWeek.Saturday);
        }

        [Test]
        public static void QuandoProxDate_DeveRetornarIntervaloMaiorQue30Dias()
        {
            //inicial
            var data_hoje = DateTime.Today;
            //açao do teste
            var result = calendario.Prox_date();
            //verificaçao teste
            Assert.That((result - data_hoje).TotalDays, Is.GreaterThanOrEqualTo(30));
        }
    }
}
