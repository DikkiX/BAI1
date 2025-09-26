using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BAI
{
    public class Opdr2Tests
    {
        [TestCase(new string[] { "-" }, new UInt64[] { 0 })]
        [TestCase(new string[] { "-", "A" }, new UInt64[] { 0, 1 })]
        [TestCase(new string[] { "-", "A", "B" }, new UInt64[] { 0, 1, 2 })]
        public void Opdr2a_WoordStack(string[] inputValues, UInt64[] expectedResult)
        {
            // Arrange
            List<string> input = new List<string>(inputValues);
            Stack<UInt64> expected = new Stack<ulong>(expectedResult);

            // Act
            Stack<UInt64> result = BAI_Afteken1.Opdr2aWoordStack(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [TestCase(new UInt64[] { }, new string[] { })]
        [TestCase(new UInt64[] { 0, 1, 2 }, new string[] { "B", "A", "-" })]
        public void Opdr2b_KorteWoordenQueue_Returns_Stack_As_Queue(UInt64[] inputValues, string[] expectedResult)
        {
            // Arrange
            Stack<UInt64> input = new Stack<ulong>(inputValues);
            Queue<string> expected = new Queue<string>(expectedResult);

            // Act
            Queue<string> result = BAI_Afteken1.Opdr2bKorteWoordenQueue(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        [TestCase(new UInt64[] { }, new string[] { })]
        [TestCase(new UInt64[] { 3, 606542, 4, 83878151, 5 }, new string[] { "E", "D", "C" })]
        public void Opdr2b_KorteWoordenQueue_Filters_Long_Words(UInt64[] inputValues, string[] expectedResult)
        {
            // Arrange
            Stack<UInt64> input = new Stack<ulong>(inputValues);
            Queue<string> expected = new Queue<string>(expectedResult);

            // Act
            Queue<string> result = BAI_Afteken1.Opdr2bKorteWoordenQueue(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
