using ConsoleApp2.Models;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Interfaces
{
    public interface IDiamondValidator
    {
        public bool Validate(CreateDiamondModel diamond, out IList<ValidationResult> errorResults);
    }
}
