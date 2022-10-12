using ConsoleApp2.Interfaces;

namespace ConsoleApp2.Test
{
    public class DiamondValidatorTests
    {
        private DiamondValidator _diamondValidator;

        [OneTimeSetUp]
        public void Setup()
        {
            _diamondValidator = new DiamondValidator();
        }

        [Test]
        public void Validate_ThrowsArgumentNullException_WhenModelNull()
        {
            Assert.Throws<ArgumentNullException>(() => _diamondValidator.Validate(null, out _));
        }

        [TestCaseSource(nameof(NonAsciiLetters))]
        public void Validate_ReturnValidationError_WhenModelNotAsciiLetter(char c)
        {
            _diamondValidator.Validate(new Models.CreateDiamondModel(c), out var errors);

            Assert.Greater(errors?.Count(), 0);
        }

        [TestCaseSource(nameof(AsciiLetters))]
        public void Validate_Success_WhenAsciiLetter(char c)
        {
            _diamondValidator.Validate(new Models.CreateDiamondModel(c), out var errors);

            Assert.AreEqual(errors.Count, 0);
        }

        static char[] AsciiChars = Enumerable.Range(0, 255).Select(x => (char)x).ToArray();

        static char[] AsciiLetters = AsciiChars.Where(x => char.IsAscii(x) && char.IsLetter(x)).ToArray();

        static char[] NonAsciiLetters = AsciiChars.Where(x => !char.IsAscii(x) || !char.IsLetter(x)).ToArray();
    }
}