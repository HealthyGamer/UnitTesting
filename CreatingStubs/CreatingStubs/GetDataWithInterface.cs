using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingStubs
{
    public class GetDataWithInterface
    {
        private IUserRepository userRepo;

        public GetDataWithInterface(IUserRepository repo)
        {
            this.userRepo = repo;
        }

        public string SelectById(int id)
        {
            var name = userRepo.GetUsernameById(id);

            if (name == "Bob")
            {
                return "Panda";
            }

            return name;
        }
    }
}
