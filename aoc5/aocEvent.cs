using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace aoc5
{
    public abstract class aocEvent
    {
        private readonly string inputFileName;
        private readonly IInputFileService inputFileService;
        protected readonly string? lineSplitter = Environment.NewLine;
        public static int numDays;
        protected aocEvent(string _inputFileName, IInputFileService _inputFileService)
        {
            inputFileName = _inputFileName;
            inputFileService = _inputFileService;
            standardInput = getInputs(lineSplitter);
            numDays++;
        }

        public IEnumerable<string> standardInput { get; set; }
        protected IEnumerable<string> getInputs(string? _lineSplitter = null)
        {
            return inputFileService.getInputs(inputFileName, _lineSplitter != null ? _lineSplitter : lineSplitter);
        }
    }


}
