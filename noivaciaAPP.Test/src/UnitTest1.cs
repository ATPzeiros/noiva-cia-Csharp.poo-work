using NoivaPoo;
using NoivaCiaApp.repository;
using SQLite;
using NoivaCiaApp.mapper;
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
            Assert.That(false, Is.False);
        }
    }
}
