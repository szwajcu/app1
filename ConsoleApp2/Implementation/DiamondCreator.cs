using ConsoleApp2.Models;

namespace ConsoleApp2.Interfaces
{
    public class DiamondCreator : IDiamondCreator
    {
        const char A_LOWERCASE = (char)'a';
        const char Z_LOWERCASE = (char)'z';
        const char A_UPPERCASE = (char)'A';

        public string Create(CreateDiamondModel model)
        {
            if (model == null) throw new ArgumentNullException();

            var charactersRange = ResolveOrderedCharacters(model.Character);
            return ResolveDiamond(charactersRange);
        }

        private string ResolveDiamond(IEnumerable<char> characters)
        {
            var diamondCharacters = characters
                .Select((x, idx) => Enumerable.Repeat(x, idx + 1))
                .Concat(characters.Select((x, idx) => Enumerable.Repeat(x, idx + 1)).Reverse().Skip(1));
            return new string(diamondCharacters.SelectMany(x => x).ToArray());
        }

        private IEnumerable<char> ResolveOrderedCharacters(char endChar)
        {
            if (endChar >= A_LOWERCASE && endChar <= Z_LOWERCASE)
            {
                return Enumerable.Range(A_LOWERCASE, endChar - A_LOWERCASE + 1).Select(c => (char)c);
            }
            else
            {
                return Enumerable.Range(A_UPPERCASE, endChar - A_UPPERCASE + 1).Select(c => (char)c);
            }
        }
    }
}
