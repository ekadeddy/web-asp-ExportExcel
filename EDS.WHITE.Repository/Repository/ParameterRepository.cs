using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDS.WHITE.Entities;
using EDS.WHITE.Repository.Connection;

namespace EDS.WHITE.Repository
{
    public class ParameterRepository : IParameterRepository
    {
        private WhiteEntities db = new WhiteEntities();
        public List<ParameterEntities> GetListParameter(string parentCategory, string category)
        {
            List<ParameterEntities> result = new List<ParameterEntities>();

            if(String.IsNullOrEmpty(category))
            {
                category = "A";
            }

            try
            {
                var parameterList = from prm in db.MPM_PARAMETERS
                                    //where prm.CATEGORY.Equals(category)
                                    select new
                                    {
                                        prm.CODE,
                                        prm.DESCRIPTION
                                    };

                foreach (var item in parameterList)
                {
                    ParameterEntities newItem = new ParameterEntities();

                    newItem.CODE = item.CODE;
                    newItem.DESCRIPTION = item.DESCRIPTION;
                    result.Add(newItem);
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Gagal ambil data "+ex.Message);
            }

                return result;

        }
    }
}
