namespace HospitalPMS.Domain;

public sealed class OutPatient : Patient
{
    public override string PatientType => "OUT-PATIENT";
    public override decimal BaseMultiplier => 1.00m;

    public OutPatient(string name, int age, string department)
        : base(name, age, department) { }
}
