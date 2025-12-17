using HospitalPMS.Domain;

namespace HospitalPMS.Core;

public static class BillPrinter
{
    public static void Print(Bill bill)
    {
        Console.WriteLine();
        Console.WriteLine("=== BILL ===");
        Console.WriteLine(bill.Patient);
        Console.WriteLine($"Generated: {bill.GeneratedAt}");

        Console.WriteLine();
        Console.WriteLine("Treatments:");
        foreach (var item in bill.Items)
            Console.WriteLine($"- {item}");

        Console.WriteLine();
        Console.WriteLine($"SubTotal: INR {bill.SubTotal:n2}");
        Console.WriteLine($"After Patient Type Multiplier: INR {bill.PatientTypeAdjustedTotal:n2} (x{bill.Patient.BaseMultiplier:n2})");
        Console.WriteLine($"Billing Strategy: {bill.StrategyName}");
        Console.WriteLine();
        Console.WriteLine($"FINAL AMOUNT: INR {bill.FinalTotal:n2}");
    }
}
