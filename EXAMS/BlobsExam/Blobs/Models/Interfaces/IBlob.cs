
namespace Blobs.Models.Interfaces
{
    public interface IBlob : IBehavior, IUpdateable
    {
        string Name { get; }

        int Health { get; set; }

        int InitialHealth { get; set; }

        int Damage { get; set; }

        bool InSpecialBahavior { get; set; }

        IAttackType ProduceAttack(string attackType);

        void RespondToAttack(IAttackType attackType);
    }
}
