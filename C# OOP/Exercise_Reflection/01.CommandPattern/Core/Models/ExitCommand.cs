using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Models
{
    public class ExitCommand : ICommand
    {
        private const int OkExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(OkExitCode);
            return null;
            // return default;
        }
    }
}
