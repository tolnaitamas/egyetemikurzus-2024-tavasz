﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XWG8AW.Infrastructure;

namespace XWG8AW.UserInterface
{
    internal class Host : IHost
    {
        public void Exit()
            => Environment.Exit(0);

        public string ReadLine()
            => Console.ReadLine() ?? throw new InvalidOperationException();

        public void WriteLine(string message)
            => Console.WriteLine(message);

        public void Write(string meassage)
            => Console.Write(meassage);
    }
}
