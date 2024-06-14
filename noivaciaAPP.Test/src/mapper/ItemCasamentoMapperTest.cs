using NoivaCiaApp.entity;
using NoivaCiaApp.mapper;
using NoivaCiaApp.model;

namespace noivaciaAPP.Test.mapper
{
    class ItemCasamentoMapperTest
    {
        private ItemCasamentoMapper mapper;
        private ItemFestaEntity entity;
        private ItemCasamento model;

        private readonly string name = "Nome 123";
        private readonly float value = 12f;
        private readonly CasamentoTipoEnum tipoCasamento = CasamentoTipoEnum.STANDART;
        private readonly ItemTipoEnum tipoItem = ItemTipoEnum.COMIDA;

        [SetUp]
        public void Setup()
        {
            mapper = new ItemCasamentoMapper();
            entity = new ItemFestaEntity()
            {
                Name = name,
                Value = value,
                TipoCasamento = (int)tipoCasamento,
                TipoItem = (int)tipoItem
            };
            model = new ItemCasamento(
                Name: name, 
                Value: 0f, 
                TipoCasamento: tipoCasamento, 
                TipoItem: tipoItem
            );
        }

        [Test]
        public void WhenMappingEntityToModelItShouldHaveSameProperties()
        {
            ItemCasamento mappedModel = mapper.MapToModel(entity);
            Assert.Multiple(() =>
            {
                Assert.That(mappedModel.Name, Is.EqualTo(entity.Name));
                Assert.That(mappedModel.Price, Is.EqualTo(entity.Value));
                Assert.That(mappedModel.TipoCasamento, Is.EqualTo((CasamentoTipoEnum)entity.TipoCasamento));
                Assert.That(mappedModel.TipoItem, Is.EqualTo((ItemTipoEnum)entity.TipoItem));
            });
        }

        [Test]
        public void WhenMappingModelToEntityItShouldHaveSameProperties()
        {
            ItemFestaEntity mappedEntity = mapper.MapToEntity(model);
            Assert.Multiple(() =>
            {
                Assert.That(mappedEntity.Name, Is.EqualTo(model.Name));
                Assert.That(mappedEntity.Value, Is.EqualTo(model.Price));
                Assert.That(mappedEntity.TipoCasamento, Is.EqualTo(entity.TipoCasamento));
                Assert.That(mappedEntity.TipoItem, Is.EqualTo(entity.TipoItem));
            });
        }
    }
}
