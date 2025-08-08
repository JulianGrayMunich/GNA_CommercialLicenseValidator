using System;
using System.Text;


namespace GNA_CommercialLicenseValidator
{
    public static class LicenseValidator
    {
        private const byte XorKey = 0x5A;

        public static void ValidateLicense(string expectedSoftwareCode, string licenseCode)
        {
            expectedSoftwareCode = expectedSoftwareCode.Trim();

            if (string.IsNullOrWhiteSpace(expectedSoftwareCode) || expectedSoftwareCode.Contains(" "))
            {
                Console.WriteLine("\nInvalid software code.\nContact gna.geomatics@gmail.com to rectify.\n");
                Console.ReadKey();
                Environment.Exit(1);
            }


            if (string.IsNullOrWhiteSpace(licenseCode) || licenseCode.Length != 16)
            {
                Console.WriteLine("\nInvalid license code format.\nContact gna.geomatics@gmail.com to rectify.\n");
                Console.ReadKey();
                Environment.Exit(1);
            }

            string codeBlock = licenseCode.Substring(0, 8);
            string dateBlock = licenseCode.Substring(8, 8);

            string decodedSoftware = DecodeBlock(codeBlock);
            string decodedDate = DecodeBlock(dateBlock);

            if (!decodedSoftware.Equals(expectedSoftwareCode, StringComparison.Ordinal))
            {
                Console.WriteLine("\nLicense software code mismatch. Application terminated.\nContact gna.geomatics@gmail.com to rectify.\n");
                Console.ReadKey();
                Environment.Exit(1);
            }

            if (!DateTime.TryParseExact(decodedDate, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime expiryDate))
            {
                Console.WriteLine("\nInvalid expiry date in license code.\nContact gna.geomatics@gmail.com to rectify.\n");

                Console.ReadKey();  
                Environment.Exit(1);
            }

            DateTime today = DateTime.Now.Date;

            if (expiryDate < today)
            {
                Console.WriteLine($"License expired on {expiryDate:yyyy-MM-dd}. \nApplication with code {expectedSoftwareCode} terminated.\nContact gna.geomatics@gmail.com to renew.\n");

                Console.ReadKey();
                Environment.Exit(1);
            }

            int daysRemaining = (expiryDate - today).Days;
            if (daysRemaining <= 5)
            {
                Console.WriteLine($"License with code {expectedSoftwareCode} will expire in {daysRemaining} day(s) on {expiryDate:yyyy-MM-dd}.\nContact gna.geomatics@gmail.com to renew.\n");

                Console.ReadKey();
            }

            // License valid
        }

        private static string DecodeBlock(string block)
        {
            var bytes = Convert.FromBase64String(block);
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] ^= XorKey;
            return Encoding.ASCII.GetString(bytes).TrimEnd('_', '\0');
        }
    }
}





