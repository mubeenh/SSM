using SSM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Core
{
    /// <summary>
    /// Core implementation of a State Machine that performs requested transitions on a given stateful entity of type T, 
    /// under the context represented by IStateMachineContext.
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public class StateMachine<T, M> where T : IStatefulEntity<M> where M: IState
    {
        readonly IStateMachineContext<T, M> Context;
        /// <summary>
        /// Constructs and initializes the state machine with given context.
        /// </summary>
        /// <param name="context"></param>
        public StateMachine(IStateMachineContext<T, M> context)
        {
            this.Context = context;
        }

        /// <summary>
        /// When called with a valid entity and transition, it uses the transition handler for the given transition (as defined in the context) to 
        /// perform the actual transition and change the state of the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transition"></param>
        /// <param name="argumentsMap">Any optional extra data that is needed for the transition. This data is passed to transition handler.</param>
        /// <returns></returns>
        public T RequestTransition(T entity, string transition, IDictionary<string, object> argumentsMap = null)
        {
            ITransitionHandler<T, M> handler;
            string currentState = entity.State == null ? "?" : entity.State.Code; // ? indicates null state
            string nextState;

            StateTransition thisTransition = Context.GetTransitions().FirstOrDefault(e => e.State == currentState && e.Transition == transition);
            
            if (thisTransition == null)
            {
                throw new Exception(String.Format("Invalid or unsupported transition - {0}", transition));
            }

            nextState = thisTransition.NextState;

            if (!Context.AllStates().Any(e => e.Code == nextState))
            {
                throw new Exception(String.Format("State: {0} is not defined.", nextState));
            }
            
            if (!Context.GetTransitionHandlersMap().TryGetValue(transition, out handler))
            {
                throw new Exception(String.Format("No handlers found for transition {0}.", transition.ToString()));
            }

            M nextStateObj = Context.AllStates().First(e => e.Code == nextState); //Get the M type object representing this state

            handler.ValidateTransition(entity, nextStateObj, argumentsMap); //Validate first

            handler.BeforeTransition(entity, argumentsMap);

            handler.Execute(entity, nextStateObj, argumentsMap);

            handler.AfterTransition(entity, argumentsMap);

            return entity;
        }
    }
}
