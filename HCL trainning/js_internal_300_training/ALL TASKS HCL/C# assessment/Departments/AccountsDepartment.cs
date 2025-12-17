using HospitalPMS.Core;

namespace HospitalPMS.Departments;

public sealed class AccountsDepartment : IDepartment
{
    public string Name => "ACCOUNTS";

    public void Subscribe(Hospital hospital)
    {
        hospital.BillGenerated += (_, e) =>
        {
            Console.WriteLine($"[{Name} NOTIFY] Bill generated for {e.Bill.Patient.Name}. Final: INR {e.Bill.FinalTotal:n2}");
        };
    }
}
