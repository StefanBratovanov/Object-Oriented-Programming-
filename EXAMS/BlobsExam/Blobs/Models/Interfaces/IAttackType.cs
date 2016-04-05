
namespace Blobs.Models.Interfaces
{
    public interface IAttackType
    {
        int Damage { get; set; }

        void Hit(IBlob targetBlob);
    }
}
