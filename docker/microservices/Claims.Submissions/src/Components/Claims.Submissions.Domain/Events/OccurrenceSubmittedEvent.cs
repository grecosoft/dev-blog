using System;
using Claims.Submissions.Domain.Entities;
using NetFusion.Messaging.Types;
using NetFusion.Messaging.Types.Attributes;

namespace Claims.Submissions.Domain.Events
{
    /// <summary>
    /// Domain event published to integrate with other Microservices
    /// when a new occurrence is submitted.
    /// </summary>
    public class OccurrenceSubmittedEvent : DomainEvent
    {
        public string OccurrenceId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PolicyNumber { get; private set; }
        public string InsuredState { get; private set; }
        public DateTime DateOfOccurrence { get; private set; }

        public static OccurrenceSubmittedEvent FromOccurrence(Occurrence occurrence)
        {
            var instance = new OccurrenceSubmittedEvent
            {
                OccurrenceId = occurrence.OccurrenceId,
                FirstName = occurrence.InsuredParty.FirstName,
                LastName = occurrence.InsuredParty.LastName,
                InsuredState = occurrence.InsuredParty.InsuredState,
                PolicyNumber = occurrence.InsuredParty.PolicyNumber,
                DateOfOccurrence = occurrence.DateOfOccurrence
            };
            
            instance.SetRouteKey(occurrence.InsuredParty.InsuredState);
            return instance;
        }
    }
}