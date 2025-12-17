using HospitalPMS.Domain;

namespace HospitalPMS.Events;

public sealed class BillGeneratedEventArgs : EventArgs
{
    public Bill Bill { get; }
    public BillGeneratedEventArgs(Bill bill) => Bill = bill;
}
