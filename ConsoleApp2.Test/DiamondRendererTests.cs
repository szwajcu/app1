using ConsoleApp2.Interfaces;
using System.Text;

namespace ConsoleApp2.Test
{
    public class DiamondRendererTests
    {
        private DiamondRenderer _diamondRenderer;
        private MemoryStream _ms;
        private StreamWriter _writer;

        [OneTimeSetUp]
        public void Setup()
        {
            _diamondRenderer = new DiamondRenderer();
            _ms = new MemoryStream();
            _writer = new StreamWriter(_ms);
        }

        [Test]
        public void Render_ThrowsArgumentNullException_WhenDiamondNull()
        {
            Assert.Throws<ArgumentNullException>(() => _diamondRenderer.Render(null, _writer));
        }

        [Test]
        public void Render_ThrowsArgumentNullException_WhenDiamondEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => _diamondRenderer.Render(String.Empty, _writer));
        }

        [Test]
        public void Render_ThrowsArgumentNullException_WhenWriterNull()
        {
            Assert.Throws<ArgumentNullException>(() => _diamondRenderer.Render("ABBA", null));
        }


        [Test]
        public void Render_OutputsDiamond()
        {
            _diamondRenderer.Render("ABBA", _writer);
            var output = Encoding.ASCII.GetString(_ms.ToArray());
            Assert.IsNotEmpty(output);
            Assert.AreEqual(output, ABBA_Output);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (_ms != null) _ms.Dispose();
            if (_writer != null) _writer.Dispose();
        }

        private readonly string ABBA_Output =
@" A 
B B
 A ";

    }
}