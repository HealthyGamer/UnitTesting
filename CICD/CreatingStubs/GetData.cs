using Microsoft.Data.Sqlite;
using System;

namespace CreatingMocks
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
                    var name =  reader.GetString(0);

                    if (name == "Bob")
                    {
                        return "Panda";
                    }

                    return name;
                }
            }
        }
    }
}
