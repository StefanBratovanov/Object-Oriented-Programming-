
namespace _03_PcCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PcCatalogMain
    {
        static void Main()
        {
            Component processor = new Component("Intel i7", 320m, "3Ghz");
            Component hdd = new Component("HDD Seagate", 120m, "500GB");
            Component ram = new Component("Ram Corsair", 79m, "8GB");
            Component graphics = new Component("Video card", 134.99m, "Ati Radeon");
            Component motherboard = new Component("Asus P5K-VM", 99.45m);
            Component monitor = new Component("Philips", 233.34m, "100 inch");

            List<Component> componentsBasic = new List<Component>() { processor, hdd, graphics, ram };
            List<Component> componentsCpuMotherboard = new List<Component>() { processor, motherboard };
            List<Component> allComponents = new List<Component>() { processor, hdd, graphics, ram, motherboard, monitor };

            Computer basicComp = new Computer("Basic", componentsBasic);
            Computer norhtBridge = new Computer("Norht Bridge", componentsCpuMotherboard);
            Computer fullComp = new Computer("full Comp", allComponents);

            List<Computer> comps = new List<Computer>() { basicComp, norhtBridge, fullComp };

            List<Computer> sortedComps = comps.OrderBy(computer => computer.Price).ToList();

            foreach (var c in sortedComps)
            {
                c.PrintConfiguration();
                Console.WriteLine();
            }
        }
    }
}
