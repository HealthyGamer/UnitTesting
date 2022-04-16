using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingMocks
{
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
}
