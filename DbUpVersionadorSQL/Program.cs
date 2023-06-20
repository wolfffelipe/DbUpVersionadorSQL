using DbUp;
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
                ?? "Server=200.214.244.210\\desenvolvimento2,11451; Database=TesteDesenvolvimento; User Id=felipe.wolf; Password=Fh6WDC@9O9u3;";
            //?? "Server=DESKTOP-Q3PMUH8; Database=DBTeste; User Id=felipe.wolff; Password=123456;";
            /*
            var connectionString =
                args.FirstOrDefault()
                ?? "Server=DESKTOP-Q3PMUH8; Database=DBTeste; Trusted_connection=true";
            */

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
