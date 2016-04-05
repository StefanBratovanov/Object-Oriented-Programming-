
namespace FootballLeague.Models
{
    using System;

    public class Match
    {
        private int id;
        private Team homeTeam;
        private Team awayTeam;
        private Score score;

        public Match(int id, Team homeTeam, Team awayTeam, Score score)
        {
            this.Id = id;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id can not be negative");
                }
                this.id = value;
            }
        }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public Score Score { get; set; }


        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.Score.HomeTeamGoals > this.Score.AwayTeamGoals ? this.HomeTeam : this.AwayTeam;
        }

        private bool IsDraw()
        {
            return this.Score.HomeTeamGoals == this.Score.AwayTeamGoals;
        }

        public override string ToString()
        {
            string output = String.Format("{0} vs {1}, {2}:{3}", this.HomeTeam.Name, this.AwayTeam.Name, this.Score.HomeTeamGoals, this.Score.AwayTeamGoals);
            if (this.GetWinner() == this.HomeTeam)
            {
                output += " ---> 1";
            }
            else if (this.GetWinner() == this.AwayTeam)
            {
                output += " ---> 2";
            }
            else
            {
                output += " ---> X";
            }
            return output;
        }
    }
}
