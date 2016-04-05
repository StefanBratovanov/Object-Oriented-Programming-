
namespace _03_CompanyHierarchy.Interfaces
{
    using System;

    public interface IProject
    {
        string Name { get; set; }
        DateTime? StartDate { get; set; }
        string Details { get; set; }
        State State { get; set; }

        void CloseProject();
    }
}
