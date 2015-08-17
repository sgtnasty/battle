using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battle
{
    public interface IConsole
    {
        void ConsoleWrite(string message);
        void ConsoleWriteLine(string message);
    }
}
