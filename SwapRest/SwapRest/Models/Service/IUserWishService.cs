using SwapRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapRest.Models.Service
{
    public interface IUserWishService : ICrudService<User_wish>
    {
        List<User_wish> FindByUser(int id);
    }
}
