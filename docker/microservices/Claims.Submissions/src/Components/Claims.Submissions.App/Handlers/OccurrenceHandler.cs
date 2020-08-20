using System.Threading.Tasks;
using Claims.Submissions.App.Repositories;
using Claims.Submissions.Domain.Commands;
using Claims.Submissions.Domain.Entities;
using Claims.Submissions.Domain.Events;
using NetFusion.Base.Validation;
using NetFusion.Messaging;

namespace Claims.Submissions.App.Handlers
{
    
    public class OccurrenceHandler : IMessageConsumer
    {
        private readonly IValidationService _validation;
        private readonly IMessagingService _messaging;
        private readonly IOccurenceRepository _occurenceRepo;
        
        public OccurrenceHandler(
            IValidationService validation,
            IMessagingService messaging,
            IOccurenceRepository occurrenceRepo)
        {
            _validation = validation;
            _messaging = messaging;
            _occurenceRepo = occurrenceRepo;
        }

        [InProcessHandler]
        public async Task<Confirmation> Record(OccurrenceCommand command)
        {
            var insured = Contact.IdentifiedAs(command.FirstName, command.LastName, command.DateOfBirth)
                .PrimaryContactInfo(command.PhoneNumber)
                .InsuredBy("Docker Insurance Company Inc.", command.PolicyNumber, command.InsuredState);
            
            var occurrence = Occurrence.ForInsured(insured, command.DateOfOccurrence);
            
            ValidationResultSet valResultSet = _validation.Validate(occurrence);
            if (valResultSet.IsInvalid)
            {
                return new Confirmation
                {
                    Validations = valResultSet.ObjectValidations
                };
            }
            
            await _occurenceRepo.AddOccurrenceAsync(occurrence);
            
            // Publish domain event on message bus to notify other interested Microservices.
            var domainEvent = OccurrenceSubmittedEvent.FromOccurrence(occurrence);
            await _messaging.PublishAsync(domainEvent);

            return new Confirmation
            {
                OccurrenceId =  occurrence.OccurrenceId
            };
        }

        [InProcessHandler]
        public async Task<Confirmation> Record(InvolvedPartyCommand command)
        {
            // Load the existing occurrence for which the involved party should be recorded.
            var occurrence = await _occurenceRepo.ReadOccurrenceAsync(command.OccurrenceId);
            if (occurrence == null)
            {
                return new Confirmation
                {
                    ResultMessage = "Invalid Occurrence"
                };
            }

            InvolvedParty involvedParty = CreateParty(command);
            
            ValidationResultSet valResultSet = _validation.Validate(involvedParty);
            if (valResultSet.IsInvalid)
            {
                return new Confirmation
                {
                    Validations = valResultSet.ObjectValidations
                };
            }
            
            occurrence.AddInvolvedParty(involvedParty);

            // Update the occurrence within the repository.
            await _occurenceRepo.UpdateOccurrenceAsync(occurrence);
            return new Confirmation
            {
                OccurrenceId =  occurrence.OccurrenceId
            };
        }

        // Create contact for party and associate with the involved automobile.
        private static InvolvedParty CreateParty(InvolvedPartyCommand command)
        {
            var contact = Contact.IdentifiedAs(command.FirstName, command.LastName, command.DateOfBirth)
                .InsuredBy(command.InsuranceCompany, command.PolicyNumber, command.InsuredState)
                .PrimaryContactInfo(command.PhoneNumber);
            
            return InvolvedParty.IdentifiedBy(contact, command.Vin);
        }
    }
}