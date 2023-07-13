using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc5
{
    public interface IInputFileService
    {
        IEnumerable<string> getInputs(string name, string? lineSplitter = null);
    }
}
