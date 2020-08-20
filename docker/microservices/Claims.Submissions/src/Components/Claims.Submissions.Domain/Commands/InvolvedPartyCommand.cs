using System;
using Claims.Submissions.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Claims.Submissions.Domain.Commands
{
    /// <summary>
    /// Command describing a party to be associated with an occurrence.
    /// </summary>
    public class InvolvedPartyCommand : Command<Confirmation>
    {
        public string OccurrenceId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        
        public string InsuranceCompany { get; set; }
        public string InsuredState { get; set; }
        public string PolicyNumber { get; set; }
        public string Vin { get; set; }
    }
}