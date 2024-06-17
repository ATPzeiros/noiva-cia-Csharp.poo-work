using NoivaCiaApp.model;

namespace noivaciaAPP.Test
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            ItemCasamento item = new(Name: "", Value: 1, TipoCasamento: CasamentoTipoEnum.STANDART, TipoItem: ItemTipoEnum.COMIDA);
        }

        [Test]
        public void Test1()
        {
            var a = 1;
            Assert.That(a, Is.Not.EqualTo(2));
        }
    }
}
