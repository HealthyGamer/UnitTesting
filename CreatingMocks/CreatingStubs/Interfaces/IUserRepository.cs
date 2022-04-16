using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingMocks
{
    public interface IUserRepository
    {
        public string GetUsernameById(int id);
    }
}
