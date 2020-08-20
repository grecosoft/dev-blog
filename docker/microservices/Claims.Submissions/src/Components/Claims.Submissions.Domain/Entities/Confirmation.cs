using System;
using NetFusion.Base.Validation;

namespace Claims.Submissions.Domain.Entities
{
    /// <summary>
    /// Domain entity representing the result of submitting an occurrence
    /// or an involved party associated with the occurrence.
    /// </summary>
    public class Confirmation
    {
        public string OccurrenceId { get; set; }
        public Contact ClaimHandler { get; set; }
        public string ResultMessage { get; set; }

        public ObjectValidation[] Validations { get; set; } = Array.Empty<ObjectValidation>();
    }
}