using HospitalPMS.Billing;
using HospitalPMS.Core;
using HospitalPMS.Departments;
using HospitalPMS.Domain;

namespace HospitalPMS;

internal class Program
{
    static void Main()
    {
        var hospital = new Hospital();

        // Subscribe departments (event-driven)
        IDepartment[] departments =
        {
            new LabDepartment(),
            new PharmacyDepartment(),
            new AccountsDepartment()
        };
        foreach (var d in departments) d.Subscribe(hospital);

        Console.WriteLine("=== HOSPITAL PATIENT MANAGEMENT SYSTEM (Console) ===\n");

        // 1) Admit patient
        Console.Write("Enter Patient Name: ");
        string name = Input.ReadNonEmpty();

        Console.Write("Enter Patient Age: ");
        int age = Input.ReadInt(min: 0, max: 120);

        Console.Write("Enter Department (e.g., ER/Cardiology): ");
        string dept = Input.ReadNonEmpty();

        // 2) Select patient type
        Console.WriteLine();
        Console.WriteLine("Select Patient Type:");
        Console.WriteLine("1. In-Patient");
        Console.WriteLine("2. Out-Patient");
        Console.WriteLine("3. Emergency");
        Console.Write("Choice: ");
        int typeChoice = Input.ReadInt(1, 3);

        Patient patient = typeChoice switch
        {
            1 => CreateInPatient(name, age, dept),
            2 => new OutPatient(name, age, dept),
            3 => new EmergencyPatient(name, age, dept),
            _ => throw new InvalidOperationException("Invalid patient type.")
        };

        hospital.AdmitPatient(patient);

        // 3) Add treatments
        var treatments = new List<TreatmentItem>();
        Console.WriteLine();
        Console.WriteLine("Add Treatments (enter 0 to stop):");

        while (true)
        {
            Console.Write("Treatment description (or 0 to finish): ");
            string desc = (Console.ReadLine() ?? string.Empty).Trim();

            if (desc == "0") break;

            if (string.IsNullOrWhiteSpace(desc))
            {
                Console.WriteLine("Please enter a valid description.");
                continue;
            }

            Console.Write("Cost (INR): ");
            decimal cost = Input.ReadDecimal(min: 0m, max: 1_000_000m);
            treatments.Add(new TreatmentItem(desc, cost));
        }

        // 4) Select billing strategy (delegate)
        Console.WriteLine();
        Console.WriteLine("Select Billing Strategy:");
        Console.WriteLine("1. Standard (no discount)");
        Console.WriteLine("2. Insurance Coverage");
        Console.WriteLine("3. Senior Citizen Discount");
        Console.WriteLine("4. Emergency Surcharge");
        Console.Write("Choice: ");
        int stratChoice = Input.ReadInt(1, 4);

        BillingStrategy strategy;
        string strategyName;

        switch (stratChoice)
        {
            case 1:
                strategy = BillingStrategies.Standard();
                strategyName = "STANDARD";
                break;

            case 2:
                Console.Write("Insurance coverage % (e.g., 80): ");
                decimal cov = Input.ReadDecimal(0, 100);
                strategy = BillingStrategies.Insurance(cov);
                strategyName = $"INSURANCE ({cov:n0}% COVER)";
                break;

            case 3:
                Console.Write("Senior discount % (e.g., 10): ");
                decimal disc = Input.ReadDecimal(0, 100);
                strategy = BillingStrategies.SeniorCitizenDiscount(disc);
                strategyName = $"SENIOR DISCOUNT ({disc:n0}%)";
                break;

            case 4:
                Console.Write("Emergency surcharge % (e.g., 15): ");
                decimal sur = Input.ReadDecimal(0, 100);
                strategy = BillingStrategies.EmergencySurcharge(sur);
                strategyName = $"EMERGENCY SURCHARGE ({sur:n0}%)";
                break;

            default:
                throw new InvalidOperationException("Invalid strategy.");
        }

        // 5) Generate bill (this triggers BillGenerated event)
        try
        {
            Bill bill = hospital.GenerateBill(patient, treatments, strategy, strategyName);
            BillPrinter.Print(bill);
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"ERROR: {ex.Message}");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Done. Press any key to exit...");
        Console.ReadKey();
    }

    private static InPatient CreateInPatient(string name, int age, string dept)
    {
        Console.Write("Days admitted: ");
        int days = Input.ReadInt(min: 1, max: 365);
        return new InPatient(name, age, dept, days);
    }
}
