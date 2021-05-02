using Xunit;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Testing.Tests
{
    public class ToppingTests
    {
        [Fact]
        public void Test_Mozzerella()
        {
            //arrange
            var sut = new Mozzerella();

            //act
            var actual = sut.name;

            //assert
            Assert.True(actual == "Mozzerella");
        }


        [Fact]
        public void Test_Jalapeno()
        {
            //arrange
            var sut = new Jalapeno();

            //act

            //assert
            Assert.True(sut.name.Equals("Jalapeno"));
        }

        [Fact]
        public void Test_BlackBeans()
        {
            //arrange
            var sut = new BlackBeans();

            //act

            //assert
            Assert.True(sut.name.Equals("BlackBeans"));
        }

         [Fact]
        public void Test_Chedder()
        {
            //arrange
            var sut = new Chedder();

            //act

            //assert
            Assert.True(sut.name.Equals("Chedder"));
        }

         [Fact]
        public void Test_Spinach()
        {
            //arrange
            var sut = new Spinach();

            //act

            //assert
            Assert.True(sut.name.Equals("Spinach"));
        }

         [Fact]
        public void Test_FriedEgg()
        {
            //arrange
            var sut = new FriedEgg();

            //act

            //assert
            Assert.True(sut.name.Equals("FriedEgg"));
        }

         [Fact]
        public void Test_GrilledChicken()
        {
            //arrange
            var sut = new GrilledChicken();

            //act

            //assert
            Assert.True(sut.name.Equals("GrilledChicken"));
        }

         [Fact]
        public void Test_Parmesan()
        {
            //arrange
            var sut = new Parmesan();

            //act

            //assert
            Assert.True(sut.name.Equals("Parmesan"));
        }

         [Fact]
        public void Test_Pepporoni()
        {
            //arrange
            var sut = new Pepporoni();

            //act

            //assert
            Assert.True(sut.name.Equals("Pepperoni"));
        }

         [Fact]
        public void Test_Sausage()
        {
            //arrange
            var sut = new Sausage();

            //act

            //assert
            Assert.True(sut.name.Equals("Sausage"));
        }

         [Fact]
        public void Test_Tomato()
        {
            //arrange
            var sut = new Tomato();

            //act

            //assert
            Assert.True(sut.name.Equals("Tomato"));
        }

         [Fact]
        public void Test_Pineapple()
        {
            //arrange
            var sut = new Pineapple();

            //act

            //assert
            Assert.True(sut.name.Equals("Pineapple"));
        }
    }
}