using ConsoleApp2.Models;
using Microsoft.Extensions.Logging;

namespace ConsoleApp2.Interfaces
{
    public class DiamondKata : IDiamondKata
    {
        private readonly IDiamondCreator _diamondCreator;
        private readonly IDiamondRenderer _diamondRenderer;
        private readonly IDiamondValidator _diamondValidator;
        private readonly ILogger<DiamondKata> _logger;

        private readonly StreamWriter _writer;

        public DiamondKata(IDiamondCreator diamondCreator, IDiamondRenderer diamondRenderer, IDiamondValidator diamondValidator, ILogger<DiamondKata> logger,
            StreamWriter writer)
        {
            _diamondCreator = diamondCreator;
            _diamondRenderer = diamondRenderer;
            _diamondValidator = diamondValidator;
            _logger = logger;
            _writer = writer;
        }

        public void CreateDiamond(CreateDiamondModel model)
        {
            if (model == null) throw new ArgumentNullException();

            var isValid = _diamondValidator.Validate(model, out var validationResults);
            if (!isValid)
            {
                _logger.LogError($"Validation failed: {string.Join(',', validationResults.Select(x => x.ErrorMessage))}");
                throw new ArgumentException("Provided input is invalid");
            }
            var diamond = _diamondCreator.Create(model);
            _diamondRenderer.Render(diamond, _writer);
        }
    }
}
