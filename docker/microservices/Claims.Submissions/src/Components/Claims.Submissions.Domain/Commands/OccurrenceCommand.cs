using System;
using Claims.Submissions.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Claims.Submissions.Domain.Commands
{
    /// <summary>
    /// Command describing an occurrence to be recorded.
    /// </summary>
    public class OccurrenceCommand : Command<Confirmation>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string PolicyNumber { get; set; }
        public string InsuredState { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfOccurrence { get; set; }
    }
}