using SSM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Tests
{
    public class NewTransitionHandler : GenericTransitionHandler
    {
        public override string TransitionKey { get { return "Transition_New"; } }

        // override only the methods that are required
        public override ServiceTicket Execute(ServiceTicket entity, ServiceTicketState nextState, IDictionary<string, object> argumentsMap = null)
        {
            entity.State = nextState;
            return entity;
        }
    }
}
