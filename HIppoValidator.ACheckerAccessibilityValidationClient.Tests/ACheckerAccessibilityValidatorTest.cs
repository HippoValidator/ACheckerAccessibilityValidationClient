using System;
using System.Linq;
using HippoValidator.ACheckerAccessibilityValidationClient;
using NUnit.Framework;

namespace HIppoValidator.ACheckerAccessibilityValidationClient.Tests
{
    public class ACheckerAccessibilityValidatorTest
    {
        [Test, Ignore("Insert api key to run")]
        public void CanValidateWebsite()
        {
            // Arrange
            var validator = new ACheckerAccessibilityValidator("INSERT_KEY_HERE");

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Errors.Any());
        }
    }
}