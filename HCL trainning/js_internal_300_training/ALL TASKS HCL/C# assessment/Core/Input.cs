namespace HospitalPMS.Core;

public static class Input
{
    public static string ReadNonEmpty()
    {
        while (true)
        {
            string? s = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
            Console.Write("Input cannot be empty. Try again: ");
        }
    }

    public static int ReadInt(int min, int max)
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int val) && val >= min && val <= max)
                return val;

            Console.Write($"Enter a number between {min} and {max}: ");
        }
    }

    public static decimal ReadDecimal(decimal min, decimal max)
    {
        while (true)
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal val) && val >= min && val <= max)
                return val;

            Console.Write($"Enter a valid amount between {min} and {max}: ");
        }
    }
}
