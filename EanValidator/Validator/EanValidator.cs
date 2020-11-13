using System;
using System.Collections.Generic;
using System.Text;

namespace EanValidator.Validator
{
    internal abstract class EanValidator
    {
        internal abstract int NUMBER_OF_DIGITS { get; }
        internal abstract bool IsValid(string EAN);
        protected void Validate(string EAN)
        {
            if (!long.TryParse(EAN, out long NumericEan))
                throw new ArgumentException($"'{nameof(EAN)}' isn't a number.", nameof(EAN));

            if (EAN.Length != NUMBER_OF_DIGITS)
                throw new ArgumentException($"'{nameof(EAN)}' should have {NUMBER_OF_DIGITS} digits.", nameof(EAN));
        }
    }
}
