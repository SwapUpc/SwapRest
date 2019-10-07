using SwapRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapRest.Models.Service
{
    public interface ILanguageService : ICrudService<Language>
    {
        List<int> WantToLearn(int id);
        List<int> WantToTeach(int id);
    }
}
