using CreatingStubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStubs.Unitest
{
    internal class UserRepositoryFake : IUserRepository
    {
        private string username;

        public UserRepositoryFake(string name)
        {
            username = name;
        }
        public string GetUsernameById(int id)
        {
            return username;
        }
    }
}
