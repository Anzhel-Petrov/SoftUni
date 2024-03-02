using System.Collections.Generic;

namespace _07.MilitaryElite.Interfaces
{
    public interface ICommando
    {
        public string MissionState { get; set; }
        public Dictionary<string, string> Missions { get; set; }
    }
}
