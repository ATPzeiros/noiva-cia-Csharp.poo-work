using NoivaCiaApp.model;

namespace noivaciaAPP.Test
{
    public class NovoTest
    {

        [SetUp]
        public void Setup()
        {
            ItemCasamento item = new(Id: 1, Name: "", Value: 1f, TipoCasamento: CasamentoTipoEnum.STANDART, TipoItem: ItemTipoEnum.COMIDA);
        }

        [Test]
        public void Test1()
        {
            Assert.That(false, Is.False);
        }
    }
}
