using SSM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSM.Tests
{
    public class ServiceTicketState : IState
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
