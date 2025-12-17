namespace HospitalPMS.Domain;

public abstract class Patient
{
    public Guid PatientId { get; } = Guid.NewGuid();
    public string Name { get; }
    public int Age { get; }
    public string Department { get; }
    public DateTime AdmittedAt { get; } = DateTime.Now;

    protected Patient(string name, int age, string department)
    {
        Name = name;
        Age = age;
        Department = department;
    }

    public abstract string PatientType { get; }
    public virtual decimal BaseMultiplier => 1.0m;

    public override string ToString()
        => $"{PatientType} | {Name} (Age: {Age}) | Dept: {Department} | ID: {PatientId}";
}
