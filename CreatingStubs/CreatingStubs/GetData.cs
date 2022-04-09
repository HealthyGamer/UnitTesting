using Microsoft.Data.Sqlite;
using System;

namespace CreatingStubs
{
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
}
