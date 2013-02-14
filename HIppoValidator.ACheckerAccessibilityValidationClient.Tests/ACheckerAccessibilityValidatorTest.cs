using System;
using System.Linq;
using HippoValidator.ACheckerAccessibilityValidationClient;
using NUnit.Framework;

namespace HIppoValidator.ACheckerAccessibilityValidationClient.Tests
{
    public class ACheckerAccessibilityValidatorTest
    {
        [Test]
        public void CanValidateWebsite()
        {
            // Arrange
            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            var validator = new ACheckerAccessibilityValidator(apiKey);

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Errors.Any());
        }
    }
}