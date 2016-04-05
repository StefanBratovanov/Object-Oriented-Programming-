
namespace FootballLeague
{
    using System;
    using Models;
    using System.Linq;

    public class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();

            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;

                case "AddMatch":
                    AddMatch(inputArgs[1], inputArgs[2], inputArgs[3], inputArgs[4], inputArgs[5]);
                    break;

                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputArgs[1], inputArgs[2], inputArgs[3], inputArgs[4], inputArgs[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
            }
        }

        private static void ListMatches()
        {
            foreach (var match in League.Matches)
            {
                Console.WriteLine(match);
            }
        }

        private static void ListTeams()
        {
            foreach (var team in League.Teams)
            {
                Console.WriteLine(team);
            }
        }

        private static void AddPlayerToTeam(string firstName, string lastName, string yearBorn, string salary, string team)
        {
            var leagueTeam = League.Teams.FirstOrDefault(t => t.Name == team);

            var player = new Player(firstName, lastName, DateTime.Parse(yearBorn), decimal.Parse(salary), leagueTeam);
            leagueTeam.AddPlayer(player);
        }

        private static void AddMatch(string id, string home, string away, string homeGoals, string awayGoals)
        {
            var score = new Score(int.Parse(homeGoals), int.Parse(awayGoals));

            var homeTeam = League.Teams.FirstOrDefault(t => t.Name == home);
            var awayTeam = League.Teams.FirstOrDefault(t => t.Name == away);

            if (home == away)
            {
                throw new ArgumentException("Away team can not be the same as home team");
            }

            var match = new Match(int.Parse(id), homeTeam, awayTeam, score);

            if (League.Matches.Any((m => m.Id == match.Id)))
            {
                throw new InvalidOperationException("Match with the same Id already exists in the league");
            }

            League.AddMatch(match);
            Console.WriteLine("Match Added");
        }

        private static void AddTeam(string name, string nick, DateTime foundedIn)
        {
            var team = new Team(name, nick, foundedIn);

            if (League.Teams.Any((t => t.Name == team.Name)))
            {
                throw new InvalidOperationException("Team already exists in the league");
            }

            League.AddTeam(team);
            Console.WriteLine("Team Added");
        }


    }
}
