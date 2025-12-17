using HospitalPMS.Core;

namespace HospitalPMS.Departments;

public sealed class PharmacyDepartment : IDepartment
{
    public string Name => "PHARMACY";

    public void Subscribe(Hospital hospital)
    {
        hospital.BillGenerated += (_, e) =>
        {
            bool hasMedicine = e.Bill.Items.Any(i =>
                i.Description.Contains("Medicine", StringComparison.OrdinalIgnoreCase));

            if (hasMedicine)
                Console.WriteLine($"[{Name} NOTIFY] Prepare medicines for {e.Bill.Patient.Name}.");
        };
    }
}
