
namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Name { get; set; }

        IList<string> Parameters { get; set; }

    }
}
