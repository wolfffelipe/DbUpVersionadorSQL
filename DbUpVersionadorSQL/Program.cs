﻿using DbUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbUpVersionadorSQL
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? "Server=DESKTOP-Q3PMUH8; Database=DBTeste; Trusted_connection=true";

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
