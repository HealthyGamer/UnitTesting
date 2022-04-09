using CreatingStubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStubs.Unitest
{
    internal class UserRepositoryStub : IUserRepository
    {
        private string username;

        public UserRepositoryStub(string name)
        {
            username = name;
        }
        public string GetUsernameById(int id)
        {
            return username;
        }
    }
}
