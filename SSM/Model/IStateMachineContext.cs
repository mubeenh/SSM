using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Model
{
    /// <summary>
    /// Represents the context under which a State Machine (see SSM.Core.StateMachine) runs.
    /// 
    /// It provides the data that is required for the configuration and processing of transitions on a stateful entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public interface IStateMachineContext<T, M> where T : IStatefulEntity<M> where M: IState
    {
        /// <summary>
        /// Provides collection of possible StateTransitions with corresponding target states.
        /// 
        /// For example: If a service ticket has a current state of 'New' and a transition 'Transition_Open' will lead to 
        /// a target state of 'Open' can be mapped as follows:
        /// <code>
        /// Transitions.Add(new StateTransition("New", "Transition_Open", "Open"));
        /// </code>
        /// 
        /// Similarly, a back transition can also be defined based on a Current State + Transition + Next State
        /// </summary>
        /// <returns>A map of all supported transitions in the given context</returns>
        ICollection<StateTransition> GetTransitions();

        /// <summary>
        /// Provides a map of all possible transition keys and respective transition handlers (see SSM.Mode.ITransitionHandler).
        /// 
        /// Example:
        /// <code>
        /// map.Add("Transition_New", new NewTransitionHandler());
        /// </code>
        /// </summary>
        /// <returns>Map of transition keys and respective transition handlers</returns>
        IDictionary<string, ITransitionHandler<T,M>> GetTransitionHandlersMap();

        /// <summary>
        /// Provides all possible states in a state machine context.
        /// </summary>
        /// <returns></returns>
        ICollection<M> AllStates();
    }
}
