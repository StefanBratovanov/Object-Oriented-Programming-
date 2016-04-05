
namespace FootballLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LeagueMain
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                try
                {
                    LeagueManager.HandleInput(line);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                catch (InvalidOperationException oe)
                {
                    Console.WriteLine(oe.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
