# Mocks to Check Dependency Calls

Stubs are useful for replacing dependencies with simple static values we can test against, but sometimes we want to check that a specific method was called in that dependency. This may not be terribly common, but it can be useful for things like checking to make sure critical information is logged or messages are sent.

As with stubs, mocking frameworks are generally used to make this simpler, but we will create a simple example to see how the process works.

## Concrete Logger

Just as with our repository class, we'll create an interface and a concrete class in order to handle logging data about our `GetData` class.

```CSharp
public interface ILogger
{
    public void Info(string message);
    public void Warn(string message);
    public void Error(string message);
}

public class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.WriteLine(message);
    }
    public void Warn(string message)
    {
        Console.WriteLine(message);
    }

    public void Error(string message)
    {
        Console.WriteLine(message);
    }
}
```

## Adding Logging to Our GetData Class

Now that we've got our logger class, let's add it to the `GetData` class. We'll send a warning if someone tries to access the data about Bob and log an error if no name is returned. Often error logging is also captured by an external library, but here we'll use a common pattern for custom logging: Catch the error, log it, and then rethrow it to be handled further up the stack.

This is our updated class:

```CSharp
public class GetDataWithInterface
{
    private IUserRepository userRepo;
    private ILogger log;
    public GetDataWithInterface(IUserRepository repo, ILogger logger)
    {
        userRepo = repo;
        log = logger;
    }

    public string SelectById(int id)
    {
        var name = userRepo.GetUsernameById(id);

        try
        {
            if (name == "Bob")
            {
                log.Warn("Someone wants to talk to Bob");
                return "Panda";
            }

            if( name == "")
            {
                throw new Exception("Not a valid name");
            }

            log.Info($"Retrieved user {name}");

            return name;
        }
        catch (Exception ex)
        {
            log.Error(ex.Message);
            throw;
        }
    }
}
```

## Creating the Mock

Our mock is also going to be simple enough for this demo. We'll implement the three interface methods, but instead of actually logging anything, we'll increment counters so we can easily inspect which methods were called.

```CSharp
internal class LoggerMock : ILogger
{
    public int ErrorCalls = 0;
    public int InfoCalls = 0;
    public int WarnCalls = 0;

    public void Error(string message)
    {
        ErrorCalls++;
    }

    public void Info(string message)
    {
        InfoCalls++; 
    }

    public void Warn(string message)
    {
        WarnCalls++;
    }
}
```

## Updating Our Tests

We now need to update our tests to add the new logger. The new properties allow us to check to make sure we actually have logged data while calling the method without worrying about the specifics of the message.

```CSharp
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
        Assert.AreEqual(log.InfoCalls, 1);
        Assert.AreEqual(log.WarnCalls, 1);

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

        Assert.AreEqual("Panda", actual);
        Assert.AreEqual(log.InfoCalls, 1);

    }
}
```

There is also one new test case- when the database returns a blank string. We can make a new test for this can and check to make sure that it throws and exception, and that the exception is logged.

```CSharp
[Test]
public void GetData_BlankUsername_ThrowsError()
{
    IUserRepository repo = new UserRepositoryStub("");
    var log = new LoggerMock();
    var data = new GetDataWithInterface(repo, log);

    Assert.Throws<Exception>(() => data.SelectById(1));
    Assert.AreEqual(1, log.ErrorCalls);

}
```
