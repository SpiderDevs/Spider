using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Interfaces
{
    public interface IValidate
    {
        //Dictionary<string, List<string>> GetValidationDetails();
        bool IsValid();
    }
}
