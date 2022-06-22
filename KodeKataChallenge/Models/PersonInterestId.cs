using Vogen;

namespace KodeKataChallenge.Models
{
    [ValueObject(typeof(string))]
    public partial record struct PersonInterestId
    {
        private static Validation Validate(string value)
        {
            return value.Length == 10 && value.StartsWith("33", StringComparison.OrdinalIgnoreCase)
            ? Validation.Ok
            : Validation.Invalid($"Person interessent Id: {value} skal starte med 33 og skal være 10 cifre.");
        }
    }
}
