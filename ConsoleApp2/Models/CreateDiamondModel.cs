using ConsoleApp2.Extensions;

namespace ConsoleApp2.Models
{
    public class CreateDiamondModel
    {
        [RequiredASCIILetter]
        public char Character { get; private set; }

        public CreateDiamondModel(char character)
        {
            Character = character;
        }
    }
}