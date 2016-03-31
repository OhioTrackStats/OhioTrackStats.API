namespace OhioTrackStats.Database
{
    using System;
    using System.Linq;
    using System.Reflection;
    using DbUp;

    static class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault() ?? "Server=ohiotrackstats.cgky5bsj8yp4.us-east-1.rds.amazonaws.com;Database=ohiotrackstats;Uid=ots;Pwd=:f}3Xh62vNJc4Mjn:y4G;";
            var upgrader = DeployChanges.To
                .MySqlDatabase(connectionString)
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
#if DEBUG
            Console.ReadLine();
#endif
            return 0;
        }
    }
}