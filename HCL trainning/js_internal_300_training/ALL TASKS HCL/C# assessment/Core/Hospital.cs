using HospitalPMS.Billing;
using HospitalPMS.Domain;
using HospitalPMS.Events;

namespace HospitalPMS.Core;

public sealed class Hospital
{
    private readonly List<Patient> _patients = new();
    public IReadOnlyList<Patient> Patients => _patients;

    // Events
    public event EventHandler<PatientAdmittedEventArgs>? PatientAdmitted;
    public event EventHandler<BillGeneratedEventArgs>? BillGenerated;

    public void AdmitPatient(Patient patient)
    {
        _patients.Add(patient);
        PatientAdmitted?.Invoke(this, new PatientAdmittedEventArgs(patient));
    }

    public Bill GenerateBill(
        Patient patient,
        List<TreatmentItem> items,
        BillingStrategy strategy,
        string strategyName)
    {
        if (items == null || items.Count == 0)
            throw new InvalidOperationException("No treatments added. Cannot generate bill.");

        decimal subTotal = items.Sum(i => i.Cost);

        // Patient-type adjustment (polymorphism)
        decimal adjusted = subTotal * patient.BaseMultiplier;

        // Delegate strategy
        decimal finalTotal = strategy(adjusted);

        var bill = new Bill(patient, items, subTotal, adjusted, strategyName, finalTotal);

        BillGenerated?.Invoke(this, new BillGeneratedEventArgs(bill));
        return bill;
    }
}
