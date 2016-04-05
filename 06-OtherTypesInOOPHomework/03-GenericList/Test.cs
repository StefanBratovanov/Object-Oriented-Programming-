
namespace _03_GenericList
{
    using System;
    class Test
    {
        static void Main()
        {
            Type type = typeof(GenericList<>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var att in allAttributes)
            {
                if (att is VersionAttribute)
                {
                    Console.WriteLine(att);
                }
            }

            var intList = new GenericList<int>();
            var stringList = new GenericList<string>();

            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(4);
            intList.RemoveAt(0);
            intList.InsertAt(1, 17);
            intList.InsertAt(1, 17);
            intList[0] = 20;

            //myList.Clear();

            for (int i = 0; i < 18; i++)
            {
                intList.Add(i + 10);
            }
            Console.WriteLine(intList);

            Console.WriteLine(intList.FindIndexOf(15));
            Console.WriteLine(intList.Contains(15));
            Console.WriteLine();

            Console.WriteLine(intList.Min());
            Console.WriteLine(intList.Max());

            stringList.Add("A");
            stringList.Add("aaa");
            stringList.Add("bb");
            stringList.Add("AAAaa");

            Console.WriteLine(stringList);
            Console.WriteLine(stringList.Min());
            Console.WriteLine(stringList.Max());
        }
    }
}
