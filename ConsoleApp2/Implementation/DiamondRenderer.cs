using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Interfaces
{
    public class DiamondRenderer : IDiamondRenderer
    {
        public void Render(string diamond, StreamWriter writer)
        {
            if (string.IsNullOrEmpty(diamond)) throw new ArgumentNullException();
            if (writer == null) throw new ArgumentNullException();

            //group by chars to be like [['a'],['b','b'],['a']]
            var groups = diamond.Aggregate(" ", (x, xNext) => x + (x.Last() == xNext ? "" : " ") + xNext).Trim().Split(' ');

            var maxOffset = groups.Max(x => x.Count());
            var maxWidth = maxOffset * 2 - 1;

            var sb = new StringBuilder();
            char lastChar = (char)0;
            char currentChar = (char)0;
            var lastTwoCharOffset = -1;

            foreach (var group in groups)
            {
                if (group.First() == 'a' || group.First() == 'A')
                {
                    sb.Append(group.First().ToString().PadLeft(maxOffset).PadRight(maxWidth));
                    if (lastChar == 0) sb.AppendLine();
                }
                else
                {
                    var startOffset = maxOffset - group.Count() + 1;
                    currentChar = group.First();

                    lastTwoCharOffset = currentChar > lastChar ? lastTwoCharOffset + 2 : lastTwoCharOffset - 2;
                    lastChar = currentChar;

                    sb.AppendLine(
                        $"{currentChar.ToString().PadLeft(startOffset)}{currentChar.ToString().PadLeft(lastTwoCharOffset + 1)}"
                        .PadRight(maxWidth)
                        );
                }

            }
            writer.Write(sb.ToString());
            writer.Flush();
        }
    }
}
