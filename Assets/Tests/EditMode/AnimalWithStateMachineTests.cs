using Herdsman.Animals;
using Herdsman.FSM;
using Moq;
using NUnit.Framework;
using System;

namespace Herdsman.EditTests
{
    public class AnimalWithStateMachineTests
    {
        [Test]
        public void Constructor_ThrowsArgumentNullException_If_ParametersAreNull()
        {
            var animalMock = new Mock<IAnimal>();
            var mockStateMachine = new Mock<IFinishStateMachine<AnimalState>>();

            Assert.Throws<ArgumentNullException>(() => new AnimalWithStateMachine(null, mockStateMachine.Object));
            Assert.Throws<ArgumentNullException>(() => new AnimalWithStateMachine(animalMock.Object, null));
        }

        [Test]
        public void Reset_Changes_StateMachine_To_IdleState()
        {
            // Arrange
            var mockAnimal = new Mock<IAnimal>();
            var mockStateMachine = new Mock<IFinishStateMachine<AnimalState>>();
            var animalWithStateMachine = new AnimalWithStateMachine(mockAnimal.Object, mockStateMachine.Object);

            // Act
            animalWithStateMachine.Reset();

            // Assert
            mockStateMachine.Verify(m => m.ChangeState(AnimalState.Idle), Times.Once);
        }

        [Test]
        public void Reset_Calls_Reset_On_Underlying_Animal()
        {
            // Arrange
            var mockAnimal = new Mock<IAnimal>();
            var mockStateMachine = new Mock<IFinishStateMachine<AnimalState>>();
            var animalWithStateMachine = new AnimalWithStateMachine(mockAnimal.Object, mockStateMachine.Object);

            // Act
            animalWithStateMachine.Reset();

            // Assert
            mockAnimal.Verify(a => a.Reset(), Times.Once);
        }

        [Test]
        public void Follow_Changes_State_To_FollowState()
        {
            // Arrange
            var mockAnimal = new Mock<IAnimal>();
            var mockStateMachine = new Mock<IFinishStateMachine<AnimalState>>();
            var animalWithStateMachine = new AnimalWithStateMachine(mockAnimal.Object, mockStateMachine.Object);

            // Act
            animalWithStateMachine.Follow();

            // Assert
            mockStateMachine.Verify(m => m.ChangeState(AnimalState.Follow), Times.Once);
        }

        [Test]
        public void Tick_Calls_Execute_On_StateMachine()
        {
            // Arrange
            var mockAnimal = new Mock<IAnimal>();
            var mockStateMachine = new Mock<IFinishStateMachine<AnimalState>>();
            var animalWithStateMachine = new AnimalWithStateMachine(mockAnimal.Object, mockStateMachine.Object);

            // Act
            animalWithStateMachine.Tick();

            // Assert
            mockStateMachine.Verify(m => m.Execute(), Times.Once);
            mockAnimal.Verify(m => m.Tick(), Times.Once);
        }
    }
}
