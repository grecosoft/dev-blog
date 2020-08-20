using System;

namespace Claims.Alerts.Domain.Entities
{
    public class OccurrenceAlert
    {
        public string OccurrenceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuredState { get; set; }
        public DateTime DateOfOccurrence { get; set; }
    }
}