﻿using System;
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
            var validator = new ACheckerAccessibilityValidator("a24ff92797f43c977d75eabccbdb300cb54b1d53");

            // Act
            var result = validator.Validate(new Uri("http://www.hippovalidator.com"));

            // Assert
            Assert.That(result.Errors.Any());
        }
    }
}