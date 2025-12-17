namespace HospitalPMS.Domain;

public sealed class Bill
{
    public Patient Patient { get; }
    public IReadOnlyList<TreatmentItem> Items { get; }
    public decimal SubTotal { get; }
    public decimal PatientTypeAdjustedTotal { get; }
    public string StrategyName { get; }
    public decimal FinalTotal { get; }
    public DateTime GeneratedAt { get; } = DateTime.Now;

    public Bill(
        Patient patient,
        IReadOnlyList<TreatmentItem> items,
        decimal subTotal,
        decimal patientTypeAdjustedTotal,
        string strategyName,
        decimal finalTotal)
    {
        Patient = patient;
        Items = items;
        SubTotal = subTotal;
        PatientTypeAdjustedTotal = patientTypeAdjustedTotal;
        StrategyName = strategyName;
        FinalTotal = finalTotal;
    }
}
