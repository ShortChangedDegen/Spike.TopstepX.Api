using System;
using Spike.TopstepX.Api.Common;

namespace Spike.TopstepX.Api.Tests.Common
{    
    // Just some basic and common tests to stub out the structure of the project.

    public class StringExtensionTests
    {
        [Fact]
        public void ToCamelCase_ShouldReturnExpectedString_WhenProvidedValueThatIsNotNull()
        {
            const string providedString = "THISISASTRING";

            var actualString = providedString.ToCamelCase();

            Assert.Equal("tHISISASTRING", actualString);
        }

        [Fact]
        public void ToCamelCase_ShouldReturnNull_WhenProvidedValueIsNull()
        {
            string providedString = null;

            var actualString = providedString.ToCamelCase();

            Assert.Null(actualString);
        }

        [Fact]
        public void ToCamelCase_ShouldReturnEmptyString_WhenProvidedValueIsEmpty()
        {
            const string providedString = "";

            var actualString = providedString.ToCamelCase();

            Assert.Equal("", actualString);
        }
    }
}
