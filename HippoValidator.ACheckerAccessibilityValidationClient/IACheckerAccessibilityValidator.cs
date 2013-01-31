using System;

namespace HippoValidator.ACheckerAccessibilityValidationClient
{
    public interface IACheckerAccessibilityValidator
    {
        ValidationResult Validate(Uri url);
    }
}