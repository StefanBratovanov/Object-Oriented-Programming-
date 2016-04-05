

using System.Linq;

namespace FootballLeague.Models
{
    using System;
    using System.Collections.Generic;

    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        }

        public static void AddTeam(Team team)
        {
            if (CheckIfTeamExists(team))
            {
                throw new InvalidOperationException("Team already exists in the league");
            }

            teams.Add(team);
        }

        private static bool CheckIfTeamExists(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }

        public static void AddMatch(Match match)
        {
            if (CheckForValidMatch(match))
            {
                throw new InvalidOperationException("Match with the same Id already exists in the league");
            }

            matches.Add(match);
        }

        private static bool CheckForValidMatch(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }
    }
}
