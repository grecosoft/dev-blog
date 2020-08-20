using System;
using System.Collections.Generic;
using NetFusion.Base.Validation;

namespace Claims.Submissions.Domain.Entities
{
    /// <summary>
    /// Entity representing an occurrence consisting of the insured and
    /// and additional involved parties.
    /// </summary>
    public class Occurrence : IValidatableType
    {
        // Occurrence level information:
        public string OccurrenceId { get; private set; }
        public DateTime DateOfOccurrence { get; private set; }
        public DateTime DateReported { get; private set; }
        
        // Involved Parties:
        public Contact InsuredParty { get; private set; }
        public Vehicle InsuredVehicle { get; private set; }
        public bool IsMinorInvolved => false;    
        
        // Claim Assignments;
        public Contact AssignedHandler { get; private set; }
        
        private List<InvolvedParty> _involvedParties = new List<InvolvedParty>();

        public static Occurrence ForInsured(Contact insured, DateTime dateOfOccurrence)
        {
            if (insured == null) throw new ArgumentNullException(nameof(insured));
            
            return new Occurrence
            {
                InsuredParty = insured, 
                DateOfOccurrence =  dateOfOccurrence,
                DateReported = DateTime.UtcNow
            };
        }

        public IReadOnlyCollection<InvolvedParty> InvolvedParties => _involvedParties;

        public Occurrence HandledBy(Contact handler)
        {
            AssignedHandler = handler ?? throw new ArgumentNullException(nameof(handler));
            return this;
        }

        public Occurrence InvolvedVehicle(Vehicle vehicle)
        {
            InsuredVehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
            return this;
        }

        public Occurrence AddInvolvedParty(InvolvedParty party)
        {
            if (party == null) throw new ArgumentNullException(nameof(party));
            _involvedParties.Add(party);
            return this;
        }

        public void Validate(IObjectValidator validator)
        {
            validator.Verify(DateOfOccurrence <= DateReported, 
                "Occurrence date must be equal or fall before Reported date.");
            
            validator.AddChildren(InsuredParty);
        }
    } 
}