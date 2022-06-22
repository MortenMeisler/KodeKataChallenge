using KodeKataChallenge.Models;

namespace KodeKataChallenge
{
    public class OvkService : IOvkService
    {
        private readonly InternalOvkService _internalOvkService;
        public OvkService(InternalOvkService internalOvkService)
        {
            _internalOvkService = internalOvkService;
        }
        public string FindOVKKode(string indberetterkode, string virksomhed, string person)
        {
            return _internalOvkService.GetOvkCode(indberetterkode, virksomhed, PersonInterestId.From(person));
        }
    }
}
