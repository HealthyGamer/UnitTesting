using CreatingMocks;
using NUnit.Framework;
using System;

namespace CreatingMocks.UnitTest
{
public class Tests
{

    [Test]
    public void GetData_UsernameBob_ReturnsPanda()
    {
        IUserRepository repo = new UserRepositoryStub("Bob");
        var log = new LoggerMock();
        var data = new GetDataWithInterface(repo, log);

        var actual = data.SelectById(1);

        Assert.AreEqual("Panda", actual);
        Assert.AreEqual(1, log.WarnCalls);

        }

        [Test]
        public void GetData_BlankUsername_ThrowsError()
        {
            IUserRepository repo = new UserRepositoryStub("");
            var log = new LoggerMock();
            var data = new GetDataWithInterface(repo, log);

            Assert.Throws<Exception>(() => data.SelectById(1));
            Assert.AreEqual(1, log.ErrorCalls);

        }

        [Test]
        [TestCase("foo")]
        [TestCase("whatever")]
        [TestCase("test")]
        public void GetData_OtherUsername_ReturnsUsername(string name)
        {
            IUserRepository repo = new UserRepositoryStub(name);
            var log = new LoggerMock();
            var data = new GetDataWithInterface(repo, log);

            var actual = data.SelectById(1);

            Assert.AreEqual(actual, name);
            Assert.AreEqual( 1, log.InfoCalls);

        }
    }
}