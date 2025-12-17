using HospitalPMS.Core;

namespace HospitalPMS.Departments;

public sealed class LabDepartment : IDepartment
{
    public string Name => "LAB";

    public void Subscribe(Hospital hospital)
    {
        hospital.PatientAdmitted += (_, e) =>
        {
            Console.WriteLine($"[{Name} NOTIFY] New admission: {e.Patient.Name} ({e.Patient.PatientType}) in {e.Patient.Department}.");
        };
    }
}
