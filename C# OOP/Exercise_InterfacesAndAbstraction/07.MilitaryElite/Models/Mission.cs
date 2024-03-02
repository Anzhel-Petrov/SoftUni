using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class Mission
    {
        private State _state;
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public State State 
        {
            get => _state;
            set
            {
                if (value is not State.inPorgress or State.Finished)
                {
                    throw new ArgumentException();
                }
                _state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = State.Finished;    
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }

    public enum State
    {
        inPorgress,
        Finished
    }
}
