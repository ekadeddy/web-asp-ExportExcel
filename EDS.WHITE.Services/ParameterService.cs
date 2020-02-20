using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDS.WHITE.Repository;
using EDS.WHITE.Entities;
namespace EDS.WHITE.Services
{
    public class ParameterService 
    {
        IParameterRepository iRepository = new ParameterRepository();

        public List<ParameterEntities> GetListParameter(string parentCategory, string category)
        {
            return iRepository.GetListParameter(parentCategory,category);
        }
    }
}
