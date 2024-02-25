using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> _firstTeam;
        private List<Person> _reserveTeam;
        private string _name;

        public Team(string name)
        {
            _name = name;
            _firstTeam = new List<Person>();
            _reserveTeam = new List<Person>();
            
        }

        public string Name { get; set; }
        public IReadOnlyCollection<Person> FirstTeam { get => _firstTeam.AsReadOnly(); }
        public IReadOnlyCollection<Person> ReserveTeam { get => _reserveTeam.AsReadOnly(); }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                _firstTeam.Add(person);
            }
            else
            {
                _reserveTeam.Add(person);
            }
        }
    }
}
