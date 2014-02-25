using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Tests
{
    public class CloseTransitionHandler : GenericTransitionHandler
    {
        public override string TransitionKey { get { return "Transition_Close"; } }

        public override ServiceTicket Execute(ServiceTicket entity, ServiceTicketState nextState, IDictionary<string, object> argumentsMap = null)
        {
            entity.State = nextState;
            return entity;
        }
    }
}
