using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPI.HHS.Core;
using OPI.HHS.Core.Models;

namespace OPI.HHS.Core
{
    public interface IHHSService
    {
        IEnumerable<string> GetStates();
    }
}
