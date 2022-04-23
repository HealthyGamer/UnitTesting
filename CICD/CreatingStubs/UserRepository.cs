using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingMocks
{
internal class UserRepository : IUserRepository
{
    private SqliteConnection _conn;

    public UserRepository(SqliteConnection conn)
    {
        _conn = conn;
    }

    public string GetUsernameById(int id)
    {
        _conn.Open();

        var command = _conn.CreateCommand();
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

            if(name == "Bob")
            {
                return "Panda";
            }

            return name;
        }
    }
}
}
