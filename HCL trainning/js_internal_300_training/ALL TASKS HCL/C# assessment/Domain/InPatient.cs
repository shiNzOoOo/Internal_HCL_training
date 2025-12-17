namespace HospitalPMS.Domain;

public sealed class InPatient : Patient
{
    public int DaysAdmitted { get; }
    public override string PatientType => "IN-PATIENT";
    public override decimal BaseMultiplier => 1.15m;

    public InPatient(string name, int age, string department, int daysAdmitted)
        : base(name, age, department)
    {
        DaysAdmitted = Math.Max(1, daysAdmitted);
    }
}
