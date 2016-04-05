

namespace Capitalism.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IBoss
    {
        ICollection<Employee> SubordinateEmployees { get; }
    }
}
