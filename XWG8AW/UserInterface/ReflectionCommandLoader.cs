﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XWG8AW.Infrastructure;

namespace XWG8AW.UserInterface
{
    internal class ReflectionCommandLoader : ICommandProvider
    {
        public IShellCommand[] Commands { get; }

        public ReflectionCommandLoader()
        {
            Type t = typeof(ReflectionCommandLoader);
            var commands = new List<IShellCommand>();
            foreach (var type in t.Assembly.GetTypes())
            {
                if (!type.IsAbstract
                    && !type.IsInterface
                    && type.IsAssignableTo(typeof(IShellCommand)))
                {
                    object? instance = Activator.CreateInstance(type);
                    if (instance is IShellCommand command)
                    {
                        commands.Add(command);
                    }
                }
            }
            Commands = commands.ToArray();
        }
    }
}
