using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop_government_data
{
    public class Municipality
    {
        int departmentCode;
        int municipalityCode;
        String departmentName;
        String municipalityName;
        String municipalityType;

        public Municipality(int departmentCode, int municipalityCode, string departmentName, string municipalityName, string municipalityType)
        {
            this.departmentCode = departmentCode;
            this.municipalityCode = municipalityCode;
            this.departmentName = departmentName;
            this.municipalityName = municipalityName;
            this.municipalityType = municipalityType;
        }


    }

    
}
