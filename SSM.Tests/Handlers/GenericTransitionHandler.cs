using SSM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Tests
{
    /// <summary>
    /// A generic transition handler that can be used to abstract common features as well as define the basic operations
    /// for a set of transition handlers. It can be derived to create specialized transition handlers for specific cases.
    /// </summary>
    public class GenericTransitionHandler : ITransitionHandler<ServiceTicket, ServiceTicketState>
    {
        public virtual string TransitionKey { get { return ""; } }

        public virtual ServiceTicket Execute(ServiceTicket entity, ServiceTicketState nextState, IDictionary<string, object> argumentsMap = null)
        {
            entity.State = nextState;
            return entity;
        }

        public virtual ServiceTicket ValidateTransition(ServiceTicket entity, ServiceTicketState nextState, IDictionary<string, object> argumentsMap = null)
        {
            return entity;
        }

        public virtual void BeforeTransition(ServiceTicket entity, IDictionary<string, object> argumentsMap = null)
        {

        }

        public virtual void AfterTransition(ServiceTicket entity, IDictionary<string, object> argumentsMap = null)
        {

        }
    }
}
