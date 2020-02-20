using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDS.WHITE.Entities
{
    public class ParameterEntities: BusinessEntities
    {
        public long PARAMETER_ID { get; set; }
        public string CATEGORY { get; set; }
        public string CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string PARENT_CATEGORY { get; set; }
    }
}
