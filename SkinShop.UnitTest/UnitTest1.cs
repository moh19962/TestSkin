using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using UnitTest;

namespace SkinShop.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var logicProduct = new FakeDatabaseProduct();

            //Act
            var result = logicProduct.GetProducts();

           //Assert
           Assert.AreEqual(result.Products.Count, 3);
           Assert.AreEqual(result.Products[0].ProductID, 1);
           Assert.AreEqual(result.Products[1].ProductID, 9);
           Assert.AreEqual(result.Products[2].Productprice, 7);
           Assert.AreEqual(result.Products[0].Productname, "Ninja");
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            var logicCart = new FakeDatabaseCart();
            //Act;
            var result = logicCart.GetProductsFromCart(1);

            //Assert
            Assert.AreEqual(result.User.UserID, 1);
            Assert.AreEqual(result.Products[0].Productname, "Ninja");
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            var logicCart = new FakeDatabaseCart();
            //Act;
            var result = logicCart.GetProductsFromCart(2);

            //Assert
            Assert.AreEqual(result.User.UserID, 2);
            Assert.AreEqual(result.Products[0].Productname, "Binja");
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            var logicUser = new FakeDatabase();
            //Act;
            var result = logicUser.GetUser("mohammadparwani@outlook.com");

            //Assert
            Assert.AreEqual(result.Name, "Moo");
            Assert.AreEqual(result.Lastname, "Parwani");
        }

        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            var logicCart = new FakeDatabaseCart();
            //Act;
            var result = logicCart.GetSubTotal(15, 5);
            //Assert
            Assert.AreEqual(result.Products[0].SubTotal, 75);
        }

        [TestMethod]
        public void TestMethod6()
        {
            //Arrange
            var logicCart = new FakeDatabaseCart();
            //Act;
            var result = logicCart.GetSubTotal(15, 5);
            //Assert
            Assert.AreEqual(result.Products[0].SubTotal, 75);
        }

    }
}
