using NetFusion.Base.Validation;

namespace Claims.Submissions.Domain.Entities
{
    /// <summary>
    /// Domain entity representing a contact associated with
    /// an occurrence created on the insured's policy.
    /// </summary>
    public class InvolvedParty : IValidatableType
    {
        public Contact Contact { get; private set; }
        public string Vin { get; private set; }

        public static InvolvedParty IdentifiedBy(Contact contact, string vin)
        {
            return new InvolvedParty
            {
                Contact = contact,
                Vin = vin
            };
        }

        public void Validate(IObjectValidator validator)
        {
            validator.AddChild(Contact);
            validator.Verify(!string.IsNullOrWhiteSpace(Vin) && Vin.Length == 17, 
                "VIN required and must be 17 characters.");
        }
    }
}