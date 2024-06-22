using Herdsman.Animals;
using Herdsman.PositionProviders;
using Moq;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Herdsman.EditTests
{
    public class AnimalTests
    {
        [Test]
        public void Constructor_Initialize_Properties_Correctly()
        {
            // Arrange
            var mockData = new Mock<IAnimalData>();
            mockData.SetupGet(d => d.Points).Returns(10);
            mockData.SetupGet(d => d.Speed).Returns(5.0f);
            var mockPositionProvider = new Mock<IPositionProvider>();

            // Act
            var animal = new Animal(mockData.Object, mockPositionProvider.Object);

            // Assert
            Assert.AreEqual(10, animal.Points);
            Assert.AreEqual(5.0f, animal.Speed);
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_If_ParametersAreNull()
        {
            // Arrange
            var mockData = new Mock<IAnimalData>();
            var mockPositionProvider = new Mock<IPositionProvider>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Animal(null, mockPositionProvider.Object));
            Assert.Throws<ArgumentNullException>(() => new Animal(mockData.Object, null));
        }

        [Test]
        public void Move_Invokes_OnchangePosition()
        {
            // Arrange
            var mockData = new Mock<IAnimalData>();
            mockData.SetupGet(d => d.Points).Returns(10);
            mockData.SetupGet(d => d.Speed).Returns(5.0f);
            var mockPositionProvider = new Mock<IPositionProvider>();
            var animal = new Animal(mockData.Object, mockPositionProvider.Object);
            var newPosition = new Vector3(1.0f, 2.0f, 3.0f);
            bool positionChanged = false;
            animal.OnchangePosition += (position) => { positionChanged = true; };

            // Act
            animal.Move(newPosition);

            // Assert
            Assert.IsTrue(positionChanged);
        }
    }
}
