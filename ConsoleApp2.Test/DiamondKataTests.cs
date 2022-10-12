using ConsoleApp2.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Test
{
    public class DiamondKataTests
    {
        private DiamondKata _diamondKata;
        private Mock<IDiamondCreator> _diamondCreator;
        private Mock<IDiamondRenderer> _diamondRenderer;
        private Mock<IDiamondValidator> _diamondValidator;

        private Mock<ILogger<DiamondKata>> _logger;
        private StreamWriter _writer;

        [OneTimeSetUp]
        public void Setup()
        {
            _diamondCreator = new Mock<IDiamondCreator>();
            _diamondRenderer = new Mock<IDiamondRenderer>();
            _diamondValidator = new Mock<IDiamondValidator>();
            _logger = new Mock<ILogger<DiamondKata>>();
            _writer = new StreamWriter(new MemoryStream());

            _diamondKata = new DiamondKata(_diamondCreator.Object, _diamondRenderer.Object, _diamondValidator.Object,
                _logger.Object, _writer);
        }

        [Test, Order(1)]
        public void CreateDiamond_ThrowsArgumentNullException_WhenModelNull()
        {
            Assert.Throws<ArgumentNullException>(() => _diamondKata.CreateDiamond(null));
        }

        [Test, Order(2)]
        public void CreateDiamond_ThrowsArgumentException_WhenValidationFails()
        {
            var model = new Models.CreateDiamondModel('0');
            _diamondValidator.Setup(x => x.Validate(model, out It.Ref<IList<ValidationResult>>.IsAny)).Returns(false);

            Assert.Throws<ArgumentNullException>(() => _diamondKata.CreateDiamond(model));

            _diamondValidator.Verify(x => x.Validate(model, out It.Ref<IList<ValidationResult>>.IsAny), Times.Once);
            _diamondCreator.Verify(x => x.Create(model), Times.Never);
            _diamondRenderer.Verify(x => x.Render(It.IsAny<string>(), It.IsAny<StreamWriter>()), Times.Never);
        }

        [Test, Order(3)]
        public void CreateDiamond_RenderDiamond()
        {
            var model = new Models.CreateDiamondModel('0');
            _diamondValidator.Setup(x => x.Validate(model, out It.Ref<IList<ValidationResult>>.IsAny)).Returns(true);

            _diamondKata.CreateDiamond(model);

            _diamondValidator.Verify(x => x.Validate(model, out It.Ref<IList<ValidationResult>>.IsAny), Times.Once);
            _diamondCreator.Verify(x => x.Create(model), Times.Once);
            _diamondRenderer.Verify(x => x.Render(It.IsAny<string>(), It.IsAny<StreamWriter>()), Times.Once); 
        }
    }
}