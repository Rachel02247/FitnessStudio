
namespace FitnessStudio.Service
{
    public static class ValidationCheck
    {
        public static bool IsValidID(string ID)
        {
            if (string.IsNullOrEmpty(ID) || ID.Length != 9)
                return false;
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                int digit = int.Parse(ID[i].ToString());
                sum += (i % 2 + 1) * digit > 9 ? 1 + 2 * digit % 10 : (i % 2 + 1) * digit;
            }
            return (int.Parse(ID[8].ToString()) + sum) % 10 == 0;
        }

        public static bool IsValidEmail(string Email)
        {
            int indexHat = Email.IndexOf('@'), indexDot = Email.IndexOf('.');
            return string.IsNullOrEmpty(Email) || indexHat > 0 && indexDot - indexHat > 1 && indexDot != Email.Length - 1;
        }

    }
}

