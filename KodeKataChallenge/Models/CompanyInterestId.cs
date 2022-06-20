using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogen;

namespace KodeKataChallenge.Models
{
    [ValueObject(typeof(string))]
    public partial record struct CompanyInterestId
    {
        private static Validation Validate(string value) => value.Length > 10 || !value.StartsWith("32")
            ? Validation.Ok
            : Validation.Invalid($"Person interessent Id: {value} skal starte med 32 og må ikke være længere end 10 cifre.");
    }
}
