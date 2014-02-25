using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Model
{
    /// <summary>
    /// Represents a stateful entity that has State of type T.
    /// </summary>
    /// <typeparam name="T">An implementation of IState</typeparam>
    public interface IStatefulEntity<T> where T: IState
    {
        /// <summary>
        /// Represents the state of a stateful entity
        /// </summary>
        T State { get; set; }
    }
}
