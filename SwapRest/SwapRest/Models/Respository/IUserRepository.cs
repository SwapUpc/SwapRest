using SwapRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapRest.Models.Respository
{
    public interface IUserRepository: ICrudRepository<User>
    {
        User Authentication(string email, string password);
        bool ExitsEmail(string email);
        User FindByEmail(string email);
        int VerifyRol(string token);
        int GetId(string token);
        List<int> WantToTeach(int id);
    }
}
