using System;
using System.Linq;
using HippoValidator.ACheckerAccessibilityValidationClient;
using NUnit.Framework;

namespace HIppoValidator.ACheckerAccessibilityValidationClient.Tests
{
    public class ACheckerAccessibilityValidatorTest
    {
        [Test, Ignore("Needs a real key to run")]
        public void CanValidateWebsite()
        {
            // Arrange
            var validator = new ACheckerAccessibilityValidator("<insert your key here>");

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Status, Is.EqualTo(ValidationStatus.Success));
            Assert.That(result.Errors.Any());
        }

        [Test]
        public void CanReturnErrorOnInvalidKey()
        {
            // Arrange
            var validator = new ACheckerAccessibilityValidator("Invalid");

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Status, Is.EqualTo(ValidationStatus.InvalidKey));
            Assert.That(!result.Errors.Any());
        }
    }
}