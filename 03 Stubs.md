# Creating Stubs For Dependencies

## Setup

For this example we'll use a simple sqlite DB as our external dependency.

After setting up SQLite (<https://www.sqlite.org/download.html>) there's a couple of commands to run. The example code assumes the DB location is c:/sqlite

1. From command line or bash run `sqlite3 test` to create the database file.
2. Run `sqlite3` to open interactive shell.
3. `.open test.db` to load the database into the shell.
4. `CREATE TABLE test.db.user(id int PRIMARY KEY, name char(50) NOT NULL);`
5. `INSERT INTO user(id, name) VALUES (1, 'Bob');`

## Note About Stubs vs. Mocks vs. Fakes

There are three ways to replace a dependency in a testL stubs, mocks, and fakes. The definitions can get a bit fuzzy and you don't need to get too hung up on whether you are creating a mock vs. stub when building your tests.

Stub: Returns fake data for the system under test to use.

Mock: Checks to ensure the right methods were called.

Fake: (Far more useful in integration tests). A simpler but full implementation of the dependency. You might use something like an in-memory database for tests so the tests don't have to build a full DB on disk just to run one test case.

## Basic Implementation

For this example, we are going to connect to a database and read user data from it. The simplest implementation is to handle all the database code in our `GetData.cs` class. I'm going to use the `Microsoft.Data.Sqlite`, which is an implementation of the standard .NET library specifically for interacting with SQLite.

In the example code, we are creating a connection to our DB, reading a user based on the ID we passed in and then printing the results to the console.

```CSharp
public class GetData
{
    public string SelectById(int id)
    {
        using (var connection = new SqliteConnection("Data Source=c:/sqlite/test.db"))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT name
                FROM user
                WHERE id = $id
            ";
            command.Parameters.AddWithValue("$id", id);

            using (var reader = command.ExecuteReader())
            {
               reader.Read();
               return  reader.GetString(0);
            }
        }
    }
}
```

Testing code written this way would be a problem because there is no way to test the code without an actual database.

## Solving Dependency Issues Through Abstraction

In order to split apart the dependency between the code we want to test and the database, we need to create a layer that the class can use where we can plug in either the real DB or the version we will create for our test. Generally this is achieved through inheritance, leveraging things like interfaces or abstract classes where appropriate. In this case we'll leverage repository pattern to create that layer. It is a popular method of handling this issue, but there are other techniques and this capability is often built into libraries themselves.

## IUserRepository

In this case, we only need a single
