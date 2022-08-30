using JuiceShop.Entity;
using JuiceShop.Interface;
using JuiceShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Telerik.JustMock;
using Xunit;
using Xunit.Sdk;

namespace UnitTest
{

    [Trait("Category", "Juice")]
    public class JuiceBuilderTest
    {

        private IJuiceBuilder juiceBuilder;

        public JuiceBuilderTest()
        {
            // Temporary off
            //IManual manual = new Mock<IManual>().Object;
            //juiceBuilder = new JuiceBuilder(manual);

            var manualMock = new Mock<IManual>();
            manualMock.Setup(foo => foo.NumberOfFruits(It.IsAny<int>())).Returns(12);
            IManual manual = manualMock.Object;
            //var juiceBuilder = new Mock<IJuiceBuilder>();

            juiceBuilder = new JuiceBuilder(manual);
        }
        [Fact]
        public void Total_People_Is_Greater_Than_Not_Interested()
        {
            //Arrange
            IManual manual = new Mock<IManual>().Object;
            Order order = new Order { NumberOfPeople = 150, NumberOfPeopleNotInterest = 50 };
            var target = new PrivateAccessor(new JuiceBuilder(manual));

            //Act
            var original = target.CallMethod("GetNumberOfPeople", order);

            //Assert
            Assert.True((int)original > 50);
        }
        [Theory]
        [InlineData(100, 0,1)]
        [InlineData(150, 5,5)]

        public void Total_People_Is_Greater_Than_Not_Interested_2(int NumberOfPeople,int NumberOfPeopleNotInterest,int expexted)
        {
            //Arrange
            IManual manual = new Mock<IManual>().Object;
            Order order = new Order { NumberOfPeople = NumberOfPeople, NumberOfPeopleNotInterest = NumberOfPeopleNotInterest };
            var target = new PrivateAccessor(new JuiceBuilder(manual));

            //Act
            var original = target.CallMethod("GetNumberOfPeople", order);

            //Assert
            Assert.True((int)original > expexted);
        }
        [Fact]

        public void SixPerson_TwelveFruits()
        {
            //Arrange
            Order order = new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 };

            //Act
            juiceBuilder.CreateNewJuice(order);
            var original = juiceBuilder.GetJuice();

            //Assert
            Assert.Equal(original.NumberOfFruit, 12);
        }

        [Theory]
        [MemberData(nameof(GetDataForCreateNewJuice))]

        public void Two_Fruits_For_One_Person(Order order)
        {
            //Arrange
            //Act
            juiceBuilder.CreateNewJuice(order);
            var original = juiceBuilder.GetJuice();
            //Assert
            Assert.Equal(original.NumberOfFruit, 12);
        }
        public static IEnumerable<object[]> GetDataForCreateNewJuice()
        {
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 } };
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 1 } };
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 5 } };
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 7 } };
        }

        [Theory]
        [CustomDataSourceAttribute]
        public void Two_Fruits_For_One_Person_2(Order order)
        {
            //Arrange
            //Act
            juiceBuilder.CreateNewJuice(order);
            var original = juiceBuilder.GetJuice();
            //Assert
            Assert.Equal(original.NumberOfFruit, 12);
        }
    }


    public class CustomDataSourceAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new Order { NumberOfPeople = 7, NumberOfPeopleNotInterest = 3 } };
        }

    }
}
