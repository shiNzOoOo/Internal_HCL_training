using HospitalPMS.Domain;

namespace HospitalPMS.Events;

public sealed class PatientAdmittedEventArgs : EventArgs
{
    public Patient Patient { get; }
    public PatientAdmittedEventArgs(Patient patient) => Patient = patient;
}
