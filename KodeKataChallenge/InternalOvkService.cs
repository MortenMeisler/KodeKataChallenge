using KodeKataChallenge.Models;

namespace KodeKataChallenge
{
    internal class InternalOvkService
    {
        private readonly IDictionary<OvkKey, string> OvkRules;
        internal InternalOvkService(string ovkData)
        {
            OvkRules = CreateOvkRules(ovkData);
        }
        

        internal string GetOvkCode(string filingCode, string companyName, PersonInterestId personInterestId)
        {
            string? ovkCode;
            if (OvkRules.TryGetValue(new OvkKey(filingCode, companyName, personInterestId.Value), out ovkCode))
            {
                return ovkCode;
            }

            foreach (KeyValuePair<OvkKey, string> kvp in OvkRules)
            {
                if (kvp.Key.FilingCode.Equals(filingCode, StringComparison.OrdinalIgnoreCase))
                {
                    if (kvp.Key.PersonInterestId.Equals(personInterestId.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        return kvp.Value;
                    }

                    if (string.IsNullOrEmpty(kvp.Key.CompanyName) && string.IsNullOrEmpty(kvp.Key.PersonInterestId))
                    {
                        return kvp.Value;
                    }
                }
            }

            return string.Empty;
        }

        private IDictionary<OvkKey, string> CreateOvkRules(string ovkText)
        {
            return ovkText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Split(",", StringSplitOptions.TrimEntries))
                                .ToDictionary(d => new OvkKey(d[0], d[2], d[3]), d => d[1]);
        }
    }
}
