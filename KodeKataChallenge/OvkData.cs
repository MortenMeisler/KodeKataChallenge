using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodeKataChallenge
{
    public static class OvkData
    {
        public static readonly IDictionary<(string, string, string), string> OvkRules = default!;

        public static string Data = @"
            00001,17170, HAPS Aps,3376543210
            22222,42429,Werners Burgerbar,
            75005,19007,,3376119800
            30303,18621,,";
    }

    
}
