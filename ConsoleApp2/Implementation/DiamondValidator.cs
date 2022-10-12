using ConsoleApp2.Models;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Interfaces
{
    public class DiamondValidator : IDiamondValidator
    {
        public bool Validate(CreateDiamondModel model, out IList<ValidationResult> errorResults)
        {
            if (model == null) throw new ArgumentNullException();

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            errorResults = new List<ValidationResult>();

            return Validator.TryValidateObject(model, context, errorResults, true);
        }
    }
}
