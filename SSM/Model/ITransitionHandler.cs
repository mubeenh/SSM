using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Model
{
    /// <summary>
    /// Represents a component that handles a transition between a given state to target state.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public interface ITransitionHandler<T, M> where T : IStatefulEntity<M> where M: IState
    {
        /// <summary>
        /// Defines and identifies this handler with the a transition key as used in state machine configuration (see SSM.Model.IStateMachineContext)
        /// </summary>
        string TransitionKey { get; }
        /// <summary>
        /// The key method of a transition handler that is responsible for the actual processing of an stateful entity and setting new state.
        /// 
        /// Its called after methods ValidateTransition and BeforeTransition
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="nextState"></param>
        /// <param name="argumentsMap"></param>
        /// <returns></returns>
        T Execute(T entity, M nextState, IDictionary<string, object> argumentsMap = null);
        
        /// <summary>
        /// Method to perform validation on given transition. If an exception is thrown, the transition does not proceed.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="nextState"></param>
        /// <param name="argumentsMap"></param>
        /// <returns></returns>
        T ValidateTransition(T entity, M nextState, IDictionary<string, object> argumentsMap = null);
        
        /// <summary>
        /// This method is called before Exceute method of a transition handler. This allows for any pre-processing as required.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="argumentsMap"></param>
        void BeforeTransition(T entity, IDictionary<string, object> argumentsMap = null);

        /// <summary>
        /// This methods is called after Execute method of a transition handler. This allows for any post-processing as required.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="argumentsMap"></param>
        void AfterTransition(T entity, IDictionary<string, object> argumentsMap = null);
    }
}
