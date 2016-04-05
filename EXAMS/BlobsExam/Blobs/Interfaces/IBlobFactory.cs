

namespace Blobs.Interfaces
{
    using Blobs.Models.Interfaces;

    public interface IBlobFactory
    {
        IBlob ProduceBlob(string name, int health, int damage, string blobType, string attackType);
    }
}
