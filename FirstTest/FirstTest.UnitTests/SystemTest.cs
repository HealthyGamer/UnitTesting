using NUnit.Framework;
using System;

namespace FirstTest.UnitTests
{
    [TestFixture]
    public class SystemTests
    {
        private System _system;

        [SetUp]
        public void Setup()
        {
            _system = new System();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AddTwoNumbers_AddingIntegers_ShouldAddThem()
        {
            //Arrange
            var system = new System();

            //Act
            var actual = system.AddTwoNumbers(2, 2);

            //Assert
            Assert.AreEqual(4, actual);
        }

        [Test]
        [TestCase(1, 3, 4)]
        public void AddTwoNumbers_AddingIntegers_ShouldAddThem_WithCases(int num1, int num2, int expected)
        {
            //Arrange
            var system = new System();

            //Act
            var actual = system.AddTwoNumbers(num1, num2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddTwoNumbers_AddingIntegers_ShouldAddThem_WithSetup()
        {
            //Arrange
            //we don't have anything here because we are using the Setup method

            //Act
            var actual = _system.AddTwoNumbers(2, 2);

            //Assert
            Assert.AreEqual(4, actual);
        }

        [Test]
        public void AddTwoNumbers_SendingNegativeNumbers_ThrowsException()
        {

            //Assert
            Assert.Throws<Exception>(() => _system.AddTwoNumbers(-4, 0));
        }

        [Test]
        public void AddTwoNumbers_AddingIntegers_ShouldSetLastResultProperty()
        {
            //Act
            _system.AddTwoNumbers(2, 2);

            //Assert
            Assert.AreEqual(4,_system.LastResult);
        }
    }
}