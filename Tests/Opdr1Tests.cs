using System;
using NUnit.Framework;

namespace BAI
{
    public class Opdr1Tests
    {
        [TestCase("-", (UInt64)0)]
        [TestCase("A", (UInt64)1)]
        [TestCase("B", (UInt64)2)]
        [TestCase("Y", (UInt64)25)]
        [TestCase("Z", (UInt64)26)]
        public void Opdr1a_Decode_1_Char_Returns_Max_27(string input, UInt64 expected)
        {
            // Arrange

            // Act
            UInt64 actual = BAI_Afteken1.Opg1aDecodeBase27(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [TestCase("--", (UInt64)0)]
        [TestCase("-A", (UInt64)1)]
        [TestCase("A-", (UInt64)27)]
        [TestCase("AA", (UInt64)28)]
        [TestCase("AB", (UInt64)29)]
        [TestCase("AZ", (UInt64)53)]
        [TestCase("B-", (UInt64)54)]
        [TestCase("BA", (UInt64)55)]
        [TestCase("BZ", (UInt64)80)]
        [TestCase("Z-", (UInt64)702)]
        [TestCase("ZA", (UInt64)703)]
        [TestCase("ZZ", (UInt64)728)]
        public void Opdr1a_Decode_2_Char_Returns_Max_728(string input, UInt64 expected)
        {
            // Arrange

            // Act
            UInt64 actual = BAI_Afteken1.Opg1aDecodeBase27(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [TestCase("BINGO", (UInt64)1250439)]
        [TestCase("HBO-ICT", (UInt64)3136040003)]
        [TestCase("DNXHQOJVFOUUVX", UInt64.MaxValue)]
        public void Opdr1a_Decode_3_Special_Cases_Returns_Special_Values(string input, UInt64 expected)
        {
            // Arrange

            // Act
            UInt64 actual = BAI_Afteken1.Opg1aDecodeBase27(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [TestCase((UInt64)0, "-")]          // Mogelijk levert implementatie van student string "" op i.p.v. "-" (vlg. "" vs. "0" of "00000")
        [TestCase((UInt64)1, "A")]
        [TestCase((UInt64)26, "Z")]
        [TestCase((UInt64)27, "A-")]
        [TestCase((UInt64)28, "AA")]
        [TestCase((UInt64)53, "AZ")]
        [TestCase((UInt64)702, "Z-")]
        [TestCase((UInt64)703, "ZA")]
        [TestCase((UInt64)728, "ZZ")]
        [TestCase((UInt64)1250439, "BINGO")]
        [TestCase((UInt64)3136040003, "HBO-ICT")]
        public void Opdr1b_Encode_Value_Returns_Correct_String(UInt64 input, string expected)
        {
            // Arrange
            
            // Act
            string actual = BAI_Afteken1.Opg1bEncodeBase27(input);
            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}