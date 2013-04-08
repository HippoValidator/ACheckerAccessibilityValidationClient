using System.Collections.Generic;

namespace HippoValidator.ACheckerAccessibilityValidationClient
{
    public class ValidationResult
    {
        public ValidationStatus Status { get; set; }

        public List<ValidationIssue> Errors { get; set; }

        public List<ValidationIssue> Warnings { get; set; }
    }
}