using CreatingStubs;
using NUnit.Framework;

namespace UsingStubs.Unitest
{
    public class Tests
    {

        [Test]
        public void GetData_UsernameBob_ReturnsPanda()
        {
            IUserRepository repo = new UserRepositoryFake("Bob");
            var data = new GetDataWithInterface(repo);

            Assert.AreEqual("Panda", data.SelectById(1));

        }

        [Test]
        [TestCase("foo")]
        [TestCase("whatever")]
        [TestCase("test")]
        public void GetData_OtherUsername_ReturnsUsername(string name)
        {
            IUserRepository repo = new UserRepositoryFake(name);
            var data = new GetDataWithInterface(repo);

            Assert.AreEqual(name, data.SelectById(1));

        }
    }
}