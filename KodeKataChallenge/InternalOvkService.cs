using KodeKataChallenge.Models;

namespace KodeKataChallenge
{
    public class InternalOvkService
    {
        private readonly IDictionary<OvkKey, string> OvkRules;
        internal InternalOvkService(string ovkData)
        {
            OvkRules = CreateOvkRules(ovkData);
        }

        internal string GetOvkCode(string filingCode, string companyName, PersonInterestId personInterestId)
        {
            // Exact match on filingCode, company and person.
            if (OvkRules.TryGetValue(new OvkKey(filingCode, companyName, personInterestId.Value), out string? ovkCode))
            {
                return ovkCode;
            }

            foreach (KeyValuePair<OvkKey, string> kvp in OvkRules)
            {
                if (kvp.Key.FilingCode.Equals(filingCode, StringComparison.OrdinalIgnoreCase))
                {
                    // If we only have rule with filingCode, return that OvkCode  - 1st priority.
                    if (string.IsNullOrEmpty(kvp.Key.CompanyName) && string.IsNullOrEmpty(kvp.Key.PersonInterestId))
                    {
                        return kvp.Value;
                    }

                    // OvkCode for a specific person was requested - return this if we have it.
                    if (kvp.Key.PersonInterestId == personInterestId.Value)
                    {
                        return kvp.Value;
                    }

                    // OvkCode for a specific company was requested - return this second if we have it.
                    if (kvp.Key.CompanyName == companyName && string.IsNullOrEmpty(kvp.Key.PersonInterestId))
                    {
                        return kvp.Value;
                    }
                }
            }

            // If any of the above did not fullfill - return the filingCode as the OvkCode
            return filingCode;
        }

        private IDictionary<OvkKey, string> CreateOvkRules(string ovkText)
        {
            return ovkText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Split(",", StringSplitOptions.TrimEntries))
                                .ToDictionary(d => new OvkKey(d[0], d[2], d[3]), d => d[1]);
        }
    }
}
