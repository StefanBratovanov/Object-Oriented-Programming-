
namespace _02_Animals
{
    using System;
    using System.Linq;

    class TestAnimals
    {
        static void Main()
        {
            Animal[] animals =
            {
                new Dog("Tom",5,"male"),
                new Dog("Tommy",2,"male"),
                new Dog("Laska",4,"female"),
                new Cat("Sara",2,"female"),
                new Cat("Pepa",9,"female"),
                new Frog("Jaba Zelena otrovnica", 3, "female"),
                new Frog("Chervena jaba", 15, "male"),
                new Frog("Kavakashta jaba", 7, "female"),
                new Kitten("Pussy",1),
                new Tomcat("Pancho",10),
                new Tomcat("Tomcho", 2),
                new Kitten("Kitty", 2)
            };

            double avDogsAge = animals.Where(animal => animal is Dog).Average(dog => dog.Age);
            Console.WriteLine("Average dogs age: {0:f2} years", avDogsAge);

            double avCatsAge = animals.Where(animal => animal is Cat).Average(cat => cat.Age);
            Console.WriteLine("Average cats age: {0:f2} years", avCatsAge);

            double avFrogAge = animals.Where(animal => animal is Frog).Average(frog => frog.Age);
            Console.WriteLine("Average frogs age: {0:f2} years", avFrogAge);

            double avKittenAge = animals.Where(animal => animal is Kitten).Average(k => k.Age);
            Console.WriteLine("Average kittens age: {0:f2} years", avKittenAge);

            double avTomsAge = animals.Where(animal => animal is Tomcat).Average(t => t.Age);
            Console.WriteLine("Average tomcats age: {0:f2} years", avTomsAge);

            Console.WriteLine("Average age of all animals:" + animals.Average(animal => animal.Age));

            Console.WriteLine();
            foreach (var animal in animals)
            {
                animal.ProduceSound();
            }

        }
    }
}
