using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Model
{
    /// <summary>
    /// Represents and defines a transition in a state machine context.
    /// </summary>
    public class StateTransition
    {
        public readonly string State;
        public readonly string Transition;
        public readonly string NextState;

        public StateTransition(string state, string transition, string nextState)
        {
            this.State = state;
            this.Transition = transition;
            this.NextState = nextState;
        }

        public override int GetHashCode()
        {
            //Generate hash code using the attribute values so two StateTransition objects
            //are considered equal given the values are same. This method of generating hash
            //uses prime numbers and is widely explained on the web.
            return 17 + 31 * State.GetHashCode() + 31 * Transition.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            StateTransition t = obj as StateTransition;
            return t != null && this.State == t.State && this.Transition == t.Transition;
        }

        public override string ToString()
        {
            return String.Format("State: {0}, Transition: {1}, Target State: {3}", this.State.ToString(), this.Transition.ToString(), this.NextState);
        }
    }
}
