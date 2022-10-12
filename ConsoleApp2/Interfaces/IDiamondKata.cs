using ConsoleApp2.Models;
using Microsoft.Extensions.Logging;

namespace ConsoleApp2.Interfaces
{
    public interface IDiamondKata
    {
        public void CreateDiamond(CreateDiamondModel model);
    }
}
