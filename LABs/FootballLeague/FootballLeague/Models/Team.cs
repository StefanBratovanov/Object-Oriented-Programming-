
using System.Linq;

namespace FootballLeague.Models
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        private const int MinimunAllowedTeamFoundedYear = 1850;

        private string name;
        private string nickName;
        private DateTime dateFounded;
        private List<Player> players;

        public Team(string name, string nickName, DateTime dateFounded)
        {
            this.Name = name;
            this.NickName = nickName;
            this.DateFounded = dateFounded;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Name should be at least 5 characters long");
                }
                this.name = value;
            }
        }

        public string NickName
        {
            get { return this.nickName; }
            set
            {
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Nickname should be at least 5 characters long");
                }
                this.nickName = value;
            }
        }

        private bool IsValidName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 5)
            {
                return true;
            }
            return false;
        }

        public DateTime DateFounded
        {
            get { return this.dateFounded; }
            set
            {
                if (value.Year < MinimunAllowedTeamFoundedYear)
                {
                    throw new ArgumentException("Date founded can not be earlier than " + MinimunAllowedTeamFoundedYear);
                }
                this.dateFounded = value;
            }
        }

        public IEnumerable<Player> Players
        {
            get { return this.players; }
        }

        public void AddPlayer(Player player)
        {
            if (CheckIfPlayerExists(player))
            {
                throw new InvalidOperationException("Player already exists in that team");
            }
            this.players.Add(player);
        }

        private bool CheckIfPlayerExists(Player player)
        {
            return this.players.Any(pl => pl.FirstName == player.FirstName &&
                                          pl.LastName == player.LastName);
        }

        public override string ToString()
        {
            return String.Format("Team: {0}, Nickname: {1}, Founded: {2:dddd, d MMMM, yyyy}", this.Name, this.NickName, this.DateFounded);
        }
    }
}
