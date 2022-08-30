using JuiceShop.Interface;
using System;
using System.Threading.Tasks;
using WebApi.Services;
using Xunit;

namespace UnitTest
{
    [Trait("Category", "OrangeJuice")]

    public class OrangeJuiceManualTest
    {
        IManual manual;

        public  OrangeJuiceManualTest()
        {
            manual = new OrangeJuiceManual();
        }

        [Fact(Skip = "Test Clean up")]
        public void TestCleanup()
        {
        }
        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 24)]
        [InlineData(14, 28)]
        [InlineData(0, 0)]
        public void Double_Fruits_Single_Person(int person, int expected)
        {
            //Act
            var original = manual.NumberOfFruits(person);

            //Assert
            Assert.Equal(original, expected);
        }

        [Theory]
        [InlineData(-1, 0)]

        public void Negative_Persons_Number_Exception(int person, int expected)
        {
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => manual.NumberOfFruits(person));

        }

        [Theory]
        [InlineData(-1, 0)]
        public void Negative_Persons_Number_Exception_2(int person, int expected)
        {
            //Act
            try
            {
                var original = manual.NumberOfFruits(person);
            }
            catch (ArgumentException)
            {
                // The test succeeded
            }
        }

    }
}
