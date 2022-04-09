using Microsoft.Data.Sqlite;
using System;

namespace CreatingStubs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Version2();
        }

        private static void Version1()
        {
            var data = new GetData();
            Console.WriteLine($"Hello {data.SelectById(1)}");
            Console.ReadLine();
        }

        private static void Version2()
        {
            using (var connection = new SqliteConnection("Data Source=c:/sqlite/test.db"))
            {
                IUserRepository repo = new UserRepository(connection);
                var data = new GetDataWithInterface(repo);
                Console.WriteLine($"Hello {data.SelectById(1)}");
                Console.ReadLine();
            }
        }
    }
}
