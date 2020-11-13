using EanValidator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EanValidator
{

    public class EanValidationProvider
    {
        private List<Validator.EanValidator> Validators;

        public EanValidationProvider()
        {
            Validators = AbstractClassImplementationsHelper.GetEnumerableOfType<Validator.EanValidator>().ToList();
        }

        public bool IsValid(string EAN)
        {
            if (string.IsNullOrWhiteSpace(EAN))
                throw new ArgumentException($"'{nameof(EAN)}' cannot be null or whitespace", nameof(EAN));

            int eanLength = EAN.Length;
            var validator = Validators.FirstOrDefault(x => x.NUMBER_OF_DIGITS == eanLength);
            if (validator == null)
                throw new ArgumentException($"Unsupported format of '{nameof(EAN)}'.", nameof(EAN));

            return validator.IsValid(EAN);
        }
    }
}
