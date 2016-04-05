namespace _01_Persons
{
    using System;

    class PersonsMain
    {
        static void Main()
        {
            Person ivan = new Person("Ivan", 23);
            Console.WriteLine(ivan);

            Person boyko = new Person("BB", 23, "mail@boyko.com");
            Console.WriteLine(boyko);

            Person ceco = new Person("CC", 23, "");
            Console.WriteLine(ceco);

            //   Person maria = new Person("Maria", 23,"mail");
            //   Console.WriteLine(maria);
        }
    }
}
