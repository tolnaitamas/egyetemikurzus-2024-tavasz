﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XWG8AW.Infrastructure;

namespace XWG8AW.Application
{
    internal class ExitCommand : IShellCommand
    {
        public string Name => "exit";

        public void Execute(IHost host, string[] args)
        {
            host.Exit();
        }
    }
}
