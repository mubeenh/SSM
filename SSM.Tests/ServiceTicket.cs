using SSM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSM.Tests
{
    public class ServiceTicket : IStatefulEntity<ServiceTicketState>
    {
        public ServiceTicketState State { get; set; }
        public string Name { get; set; }
    }
}
