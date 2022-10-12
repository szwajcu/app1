using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Interfaces
{
    public interface IDiamondRenderer
    {
        public void Render(string diamond, StreamWriter writer);
    }
}
