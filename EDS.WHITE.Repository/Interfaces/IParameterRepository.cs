using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDS.WHITE.Entities;
namespace EDS.WHITE.Repository
{
    public interface IParameterRepository
    {
        List<ParameterEntities> GetListParameter(string parentCategory, string category);
    }
}
