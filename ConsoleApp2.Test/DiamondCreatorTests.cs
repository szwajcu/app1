using ConsoleApp2.Interfaces;

namespace ConsoleApp2.Test
{
    public class DiamondCreatorTests
    {
        private DiamondCreator _diamondCreator;

        [OneTimeSetUp]
        public void Setup()
        {
            _diamondCreator = new DiamondCreator();
        }

        [Test]
        public void Create_ThrowsArgumentNullException_WhenModelNull()
        {
            Assert.Throws<ArgumentNullException>(() => _diamondCreator.Create(null));
        }

        [Test]
        public void Create_ReturnsValidDiamondString()
        {
            var result = _diamondCreator.Create(new Models.CreateDiamondModel('c'));
            Assert.AreEqual("abbcccbba", result);
        }

        [Test]
        public void Create_ReturnsValidDiamondStringInCorrectCase()
        {
            var result = _diamondCreator.Create(new Models.CreateDiamondModel('C'));
            Assert.AreEqual("ABBCCCBBA", result);
        }

        static char[] AsciiChars = Enumerable.Range(0, 255).Select(x => (char)x).ToArray();

        static char[] AsciiLetters = AsciiChars.Where(x => char.IsAscii(x) && char.IsLetter(x)).ToArray();

        static char[] NonAsciiLetters = AsciiChars.Where(x => !char.IsAscii(x) || !char.IsLetter(x)).ToArray();
    }
}