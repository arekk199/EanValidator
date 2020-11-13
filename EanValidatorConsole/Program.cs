using System;
using System.Reflection;

namespace EANValidatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var validationProvider = new EanValidator.EanValidationProvider();

            Console.WriteLine("Input 'q' to exit the application.");
            string eanCode = "";

            try
            {
                Console.Write("\n\nEAN code: ");
                eanCode = Console.ReadLine();

                if (string.Compare(eanCode, "q", StringComparison.OrdinalIgnoreCase) == 0)
                    return;

                if (validationProvider.IsValid(eanCode))
                    Console.WriteLine("Valid");
                else
                    Console.WriteLine("Code isn't valid.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
