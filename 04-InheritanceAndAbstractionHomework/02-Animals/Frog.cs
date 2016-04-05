
namespace _02_Animals
{
    using System;

    class Frog : Animal
    {
        public Frog(string name, int age, string gender) :
            base(name, age, gender)
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Frog kwaks: Kwaky kwaky kwaky");
        }
    }
}
