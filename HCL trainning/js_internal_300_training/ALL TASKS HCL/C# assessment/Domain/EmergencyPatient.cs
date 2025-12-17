namespace HospitalPMS.Domain;

public sealed class EmergencyPatient : Patient
{
    public override string PatientType => "EMERGENCY";
    public override decimal BaseMultiplier => 1.35m;

    public EmergencyPatient(string name, int age, string department)
        : base(name, age, department) { }
}
