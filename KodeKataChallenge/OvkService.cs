using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodeKataChallenge.Models;

namespace KodeKataChallenge
{
    public class OvkService : IOvkService
    {
        private readonly InternalOvkService _internalOvkService;
        public OvkService(string ovkData)
        {
            _internalOvkService = new InternalOvkService(ovkData);
        }
        public string FindOVKKode(string indberetterkode, string virksomhed, string person)
        {
            return _internalOvkService.GetOvkCode(indberetterkode, virksomhed, PersonInterestId.From(person));
        }
    }
}
