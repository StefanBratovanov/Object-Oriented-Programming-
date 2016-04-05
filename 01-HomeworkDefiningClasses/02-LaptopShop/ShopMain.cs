
namespace _02_LaptopShop
{
    using System;

    class ShopMain
    {
        static void Main()
        {
            Laptop myLaptop = new Laptop("Acer", 1300);
            Console.WriteLine(myLaptop);
            Console.WriteLine();

            Laptop fullLaptop = new Laptop("Lenovo Yoga 2 Pro", 2259.00m, "Lenovo", "Intel Core i5-4210U(2-core, 1.70 - 2.70 GHz, 3MB cache)",
                8, "Intel HD Graphics 4400", "128SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
                new Battery("Li-Ion", 4, 2550), 4.5);
            Console.WriteLine(fullLaptop);
            Console.WriteLine();

            Laptop intermediateLaptop = new Laptop("Sony Vaio", 1399.99m, "Sony", "Intel i3-4000m");
            Console.WriteLine(intermediateLaptop);
            Console.WriteLine();
        }
    }
}
