using NoivaCiaApp.repository;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;
using Moq;
using NoivaCiaApp.persistence;
using NoivaCiaApp.entity;

namespace noivaciaAPP.Test
{
    public class ItemRepositoryTest
    {

        private Mock<IMapper<ItemCasamento, ItemFestaEntity>> mapper;
        private Mock<IDatabase> database;
        private ItemCasamentoRepository repository;

        [SetUp]
        public void Setup()
        {
            mapper = new Mock<IMapper<ItemCasamento, ItemFestaEntity>>();
            database = new Mock<IDatabase>(MockBehavior.Strict){ DefaultValue = DefaultValue.Mock };

            mapper.Setup(map => map.MapToModel(It.IsAny<ItemFestaEntity>())).Returns(ItemCasamentoStub.GenerateItemCasamento());
            database.Setup(db => db.GetEntities<ItemFestaEntity>()).Returns([ItemCasamentoStub.GenerateItemCasamentoEntity()]);

            repository = new ItemCasamentoRepository(mapper.Object, database.Object);
        }

        [Test]
        public void ItemStandard()
        {
            var items = repository.GetItemCasamentoPorTipo(
                tipo: ItemTipoEnum.COMIDA,
                casamentoTipo: CasamentoTipoEnum.LUXO
            );
            Assert.That(items, Has.Count.EqualTo(1));
        }

        [Test]
        public void ItemLuxo()
        {
            var items = repository.GetItemCasamentoPorTipo(
                tipo: ItemTipoEnum.COMIDA,
                casamentoTipo: CasamentoTipoEnum.LUXO
            );
            Assert.That(items, Has.Count.EqualTo(0));
        }

        [Test]
        public void ItemPremier()
        {
            var items = repository.GetItemCasamentoPorTipo(
                tipo: ItemTipoEnum.COMIDA,
                casamentoTipo: CasamentoTipoEnum.LUXO
            );
            Assert.That(items, Has.Count.EqualTo(0));
        }
    }
}
