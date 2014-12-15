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
        string GetCountyByCase(string caseNum);
        IEnumerable<AddressSearchResult> SearchByCityState(string st, string city);
        IEnumerable<AddressSearchResult> SearchByCase(int caseNumber);
        IEnumerable<ReferralSearchResult> SearchByName(string lastname);
        IEnumerable<Relationship> GetParentsByCase(string caseNum);
        IEnumerable<ReferralSearchResult> GetReferralsByCase(string caseNum);
        IEnumerable<Program> GetProgramsByCase(string caseNum);


    }
}
