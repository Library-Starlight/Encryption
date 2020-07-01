using System;
using Xunit;

namespace Encryption.Irreversible.xUT
{
    public class MD5
    {
        [Theory]
        [InlineData("123456", "E10ADC3949BA59ABBE56E057F20F883E")]
        [InlineData("5555fdsfs23frw", "A754AB5DC648E07532CA46A16E583251")]
        public void Test(string input, string except)
        {
            var result = MD5Encrypt.Encrypt(input);

            Assert.Equal(except, result);
        }
    }
}
