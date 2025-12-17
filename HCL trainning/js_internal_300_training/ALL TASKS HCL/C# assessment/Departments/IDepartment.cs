using HospitalPMS.Core;

namespace HospitalPMS.Departments;

public interface IDepartment
{
    string Name { get; }
    void Subscribe(Hospital hospital);
}
