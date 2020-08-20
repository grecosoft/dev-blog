using System;
using NetFusion.Base.Validation;

namespace Claims.Submissions.Domain.Entities
{
    /// <summary>
    /// Domain entity representing an insurance contact.
    /// </summary>
    public class Contact : IValidatableType
    {
        // Identification:
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        
        // Associated Insurance Company:
        public string InsuranceCompany { get; set; }
        public string PolicyNumber { get; private set; }
        public string InsuredState { get; private set; }
        
        // Initial Contact Information:
        public string PhoneNumber { get; private set; }
        public string SecondaryPhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }

        public static Contact IdentifiedAs(string firstName, string lastName, DateTime dob)
        {
            return new Contact
            {
                FirstName = firstName,
                LastName =  lastName,
                DateOfBirth =  dob
            };
        }

        public Contact InsuredBy(string company, string policyNumber, string state)
        {
            InsuranceCompany = company;
            PolicyNumber = policyNumber;
            InsuredState = state;
            return this;
        }

        public Contact PrimaryContactInfo(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public Contact SecondaryContactInfo(string phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            EmailAddress = email;
            return this;
        }

        public void Validate(IObjectValidator validator)
        {
            validator.Verify(!string.IsNullOrWhiteSpace(FirstName) && FirstName.Length <= 60, 
                "First Name required and less than 60 characters.");
            
            validator.Verify(!string.IsNullOrWhiteSpace(LastName) && LastName.Length <= 60, 
                "Last Name required and less than 60 characters.");
            
            validator.Verify(!string.IsNullOrWhiteSpace(InsuranceCompany) && InsuranceCompany.Length <= 80, 
                "Insurance Company required and less than 80 characters.");
            
            validator.Verify(!string.IsNullOrWhiteSpace(PolicyNumber) && PolicyNumber.Length <= 50, 
                "Policy Number required and less than 50 characters.");
            
            validator.Verify(!string.IsNullOrWhiteSpace(InsuredState) && InsuredState.Length == 2, 
                "Insured State required and must be two characters.");
            
            validator.Verify(!string.IsNullOrWhiteSpace(PhoneNumber) && PhoneNumber.Length == 10, 
                "Phone Number required and must be 10 characters.");
        }
    }
}