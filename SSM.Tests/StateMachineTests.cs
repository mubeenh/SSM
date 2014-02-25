using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SSM.Model;
using SSM.Tests;
using SSM.Core;

namespace SSM.Tests
{
    [TestClass]
    public class StateMachineTests
    {
        private IStateMachineContext<ServiceTicket, ServiceTicketState> context;
        private StateMachine<ServiceTicket, ServiceTicketState> StateMachine;
        
        [TestInitialize]
        public void Initialize()
        {
            context = new ExampleStateMachineContext();
            StateMachine = new StateMachine<ServiceTicket, ServiceTicketState>(context);
        }
        
        [TestMethod]
        public void TestValidTransition()
        {
            ServiceTicket serviceTicket = new ServiceTicket()
            {
                 Name = "An example service ticket"
            };

            StateMachine.RequestTransition(serviceTicket, "Transition_New");

            Assert.IsTrue(serviceTicket.State.Code == "New");
        }

        [TestMethod]
        public void TestReverseTransition()
        {
            ServiceTicket serviceTicket = new ServiceTicket()
            {
                State = context.AllStates().First(e => e.Code == "Closed"),
                Name = "Closed service ticket"
            };

            StateMachine.RequestTransition(serviceTicket, "Transition_ReOpen");

            Assert.IsTrue(serviceTicket.State.Code == "Open");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid or unsupported transition - {0}")]
        public void TestInvalidTransition()
        {
            ServiceTicket serviceTicket = new ServiceTicket()
            {
                State = context.AllStates().First(e => e.Code == "Open"),
                Name = "An example service ticket"
            };

            StateMachine.RequestTransition(serviceTicket, "Transition_Escalate");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No handlers found for transition {0}.")]
        public void TestNoHandler()
        {
            ServiceTicket serviceTicket = new ServiceTicket()
            {
                State = context.AllStates().First(e => e.Code == "Open"),
                Name = "An example service ticket"
            };

            StateMachine.RequestTransition(serviceTicket, "Transition_Cancel");
            Assert.Fail();
        }
    }
}
