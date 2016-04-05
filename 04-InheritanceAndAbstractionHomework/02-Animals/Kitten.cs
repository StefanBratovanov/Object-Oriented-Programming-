
namespace _02_Animals
{
    using System;

    class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, "female")
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Kitten meows: Mrrrrrr, Mrrrrrr");
        }
    }
}
