namespace HospitalPMS.Domain;

public sealed class TreatmentItem
{
    public string Description { get; }
    public decimal Cost { get; }

    public TreatmentItem(string description, decimal cost)
    {
        Description = description;
        Cost = cost;
    }

    public override string ToString() => $"{Description} - INR {Cost:n2}";
}
