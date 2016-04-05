

namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;
    using System.Collections.Generic;

    public interface IDatabase
    {
        ICollection<IBlob> Blobs { get; }
    }
}
