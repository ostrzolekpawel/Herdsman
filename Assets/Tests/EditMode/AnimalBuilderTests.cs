using Herdsman.Animals;
using Herdsman.PositionProviders;
using Moq;
using NUnit.Framework;
using System;

namespace Herdsman.EditTests
{
    public class AnimalBuilderTests
    {
        [Test]
        public void Build_Animal_Without_StateMachine_Is_AnimalWithStateMachine()
        {
            // Arrange
            var mockPositionProvider = new Mock<IPositionProvider>();
            var mockHeroPositionProvider = new Mock<IPositionProvider>();
            var mockAnimalData = new Mock<IAnimalData>();

            var builder = new AnimalBuilder(mockPositionProvider.Object, mockHeroPositionProvider.Object, mockAnimalData.Object);

            // Act
            var animal = builder.WithStateMachine().Build();

            // Assert
            Assert.IsInstanceOf<AnimalWithStateMachine>(animal);
        }

        [Test]
        public void Build_Animal_Without_StateMachine_Is_Animal()
        {
            // Arrange
            var mockPositionProvider = new Mock<IPositionProvider>();
            var mockHeroPositionProvider = new Mock<IPositionProvider>();
            var mockAnimalData = new Mock<IAnimalData>();

            var builder = new AnimalBuilder(mockPositionProvider.Object, mockHeroPositionProvider.Object, mockAnimalData.Object);

            // Act
            var animal = builder.Build();

            // Assert
            Assert.IsInstanceOf<Animal>(animal);
        }

        [Test]
        public void Null_Parameters_ThrowsArgumentNullException()
        {
            // Arrange
            var nullPositionProvider = new Mock<IPositionProvider>();
            var mockHeroPositionProvider = new Mock<IPositionProvider>();
            var mockAnimalData = new Mock<IAnimalData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AnimalBuilder(null, mockHeroPositionProvider.Object, mockAnimalData.Object));
            Assert.Throws<ArgumentNullException>(() => new AnimalBuilder(nullPositionProvider.Object, null, mockAnimalData.Object));
            Assert.Throws<ArgumentNullException>(() => new AnimalBuilder(nullPositionProvider.Object, mockHeroPositionProvider.Object, null));
        }
    }
}
