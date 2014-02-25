using SSM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Tests
{
    public class ExampleStateMachineContext : IStateMachineContext<ServiceTicket, ServiceTicketState>
    {
        public ICollection<StateTransition> GetTransitions()
        {
            ICollection<StateTransition> map = new List<StateTransition>();
            // Define all possible transitions, and its source and target states
            map.Add(new StateTransition("?", "Transition_New", "New")); // ? means null or undefined state
            map.Add(new StateTransition("New", "Transition_Open", "Open"));
            map.Add(new StateTransition("Open", "Transition_Close", "Closed"));
            map.Add(new StateTransition("Closed", "Transition_ReOpen", "Open"));
            map.Add(new StateTransition("?", "Transition_Cancel", "Cancelled"));

            return map;
        }

        public IDictionary<string, ITransitionHandler<ServiceTicket, ServiceTicketState>> GetTransitionHandlersMap()
        {
            IDictionary<string, ITransitionHandler<ServiceTicket, ServiceTicketState>> map = new Dictionary<string, ITransitionHandler<ServiceTicket, ServiceTicketState>>();
            // create a map of all available transitions and their respective transition handlers
            map.Add("Transition_New", new NewTransitionHandler());
            map.Add("Transition_Open", new OpenTransitionHandler());
            map.Add("Transition_Close", new CloseTransitionHandler());
            map.Add("Transition_ReOpen", new OpenTransitionHandler());

            return map;
        }

        public ICollection<ServiceTicketState> AllStates()
        {
            List<ServiceTicketState> states = new List<ServiceTicketState>();
            // create a list of all possible states
            states.Add(new ServiceTicketState() { Code = "New", Name = "New Ticket" });
            states.Add(new ServiceTicketState() { Code = "Open", Name = "Ticket Open" });
            states.Add(new ServiceTicketState() { Code = "Closed", Name = "Ticket Closed" });
            states.Add(new ServiceTicketState() { Code = "Cancelled", Name = "Ticket Cancelled" });

            return states;
        }

    }
}
