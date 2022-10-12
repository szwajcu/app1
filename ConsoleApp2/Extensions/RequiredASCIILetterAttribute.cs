using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace ConsoleApp2.Extensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredASCIILetterAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is char && char.IsLetter((char)value) && char.IsAscii((char)value);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, "Provided character is not a valid letter", name);
        }
    }
}
