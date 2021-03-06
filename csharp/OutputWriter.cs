﻿using System;

namespace csharp
{
    public sealed class OutputWriter : IOutputWriter
    {

        public void WriteLine(string line) => Console.WriteLine(line);
        public void Write(string message) => Console.Write(message);
    }
}
