using System;
using NetFusion.Messaging.Types;

namespace Claims.Alerts.App.IntegrationEvents
{
    public class OccurrenceSubmittedEvent : DomainEvent
    {
        public string OccurrenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuredState { get; set; }
        public DateTime DateOfOccurrence { get; set; }
    }
}