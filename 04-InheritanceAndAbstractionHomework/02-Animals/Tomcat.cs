
namespace _02_Animals
{
    using System;

    class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, "male")
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Tomcat meows: Pis, Pis");
        }
    }
}
