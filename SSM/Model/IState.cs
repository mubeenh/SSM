using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM.Model
{
    /// <summary>
    /// Represents the State of a stateful entity (see IStatefulEntity) in the context of a State Machine
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Stores state's code value. This is used for look up and matching.
        /// </summary>
        string Code { get; set; }
    }
}
