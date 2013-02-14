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
            Console.WriteLine("ApiKey: " + apiKey);
            foreach (var key in Environment.GetEnvironmentVariables().Keys)
            {
                Console.WriteLine("Key: " + key + ", valuue: " + Environment.GetEnvironmentVariable(key.ToString()));
            }

            var validator = new ACheckerAccessibilityValidator(apiKey);

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Errors.Any());
        }
    }
}