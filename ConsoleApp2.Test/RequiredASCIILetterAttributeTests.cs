using ConsoleApp2.Extensions;
using ConsoleApp2.Interfaces;

namespace ConsoleApp2.Test
{
    public class RequiredASCIILetterAttributeTests
    {
        private RequiredASCIILetterAttribute _attribute;

        [OneTimeSetUp]
        public void Setup()
        {
            _attribute = new RequiredASCIILetterAttribute();
        }


        [TestCaseSource(nameof(NonAsciiLetters))]
        public void Validate_ReturnValidationError_WhenModelNotAsciiLetter(char c)
        {
            Assert.IsFalse(_attribute.IsValid(c));
        }

        [TestCaseSource(nameof(AsciiLetters))]
        public void Validate_Success_WhenAsciiLetter(char c)
        {
            Assert.IsTrue(_attribute.IsValid(c));
        }

        static char[] AsciiChars = Enumerable.Range(0, 255).Select(x => (char)x).ToArray();

        static char[] AsciiLetters = AsciiChars.Where(x => char.IsAscii(x) && char.IsLetter(x)).ToArray();

        static char[] NonAsciiLetters = AsciiChars.Where(x => !char.IsAscii(x) || !char.IsLetter(x)).ToArray();
    }
}