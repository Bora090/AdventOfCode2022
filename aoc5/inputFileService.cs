using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace aoc5
{
    public class inputFileService : IInputFileService
    {
        private static readonly string currentDir1 = Directory.GetCurrentDirectory();
        private string basePath = $"{currentDir1}/input";

        public IEnumerable<string> getInputs(string name, string? lineSplitter = null)
        {
            lineSplitter ??= Environment.NewLine;

            return getInput(name)
                .Split(lineSplitter)
                .Where(i => !string.IsNullOrWhiteSpace(i));
        }

        private string getInput(string name)
        {
            return File.ReadAllText($"{basePath}/{name}.txt");
        }
    }
}
