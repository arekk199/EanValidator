using System;
using System.Collections.Generic;
using System.Text;

namespace EanValidator.Validator
{
    internal class Ean8Validator : EanValidator
    {
        internal override int NUMBER_OF_DIGITS => 8;

        internal override bool IsValid(string EAN)
        {
            Validate(EAN);

            double sum = 0;
            for (int i = 0; i < NUMBER_OF_DIGITS - 1; i++)
            {
                var digit = Char.GetNumericValue(EAN, i);
                sum += digit * ((i % 2) == 0 ? 3 : 1);
            }
            var checksum = (10 - (sum % 10)) % 10;

            return Char.GetNumericValue(EAN, NUMBER_OF_DIGITS - 1) == checksum;
        }
    }
}
