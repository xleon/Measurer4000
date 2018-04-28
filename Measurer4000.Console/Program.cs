using System;
using System.IO;
using System.Linq;
using Measurer4000.Command.Services;
using Measurer4000.Core.Models;
using Measurer4000.Core.Services;
using Measurer4000.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace Measurer4000.Command
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InitServices();
            if(!args.Any())
            {
                PrintHelp();
            }
            else
            {
                var arguments = new MeasurerParameters(args);

                if(string.IsNullOrEmpty(arguments.SolutionFileName))
                {
                    Console.WriteLine("Solution filename not specified");
                }
                else
                {
                    Measure(arguments);
                }                
            }

#if DEBUG
            Console.WriteLine("Finito");
            Console.ReadKey();
#endif
        }

        private static void Measure(MeasurerParameters arguments)
        {
            var measurerService = ServiceLocator.Get<IMeasurerService>();

            Console.WriteLine("Getting projects");

            var projects = measurerService.GetProjects(arguments.SolutionFileName);

            Console.WriteLine("Measuring...");

            var stats = measurerService.Measure(projects);

            if (arguments.IsJson)
            {
                JsonStats(stats, arguments.Complete);
            }
            else
            {
                PrintStats(stats, arguments.Complete);
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine(@"___  ___ _____  ___   _____  _   _ ______  _____ ______     ___  _____  _____  _____ 
|  \/  ||  ___|/ _ \ /  ___|| | | || ___ \|  ___|| ___ \   /   ||  _  ||  _  ||  _  |
| .  . || |__ / /_\ \\ `--. | | | || |_/ /| |__  | |_/ /  / /| || |/' || |/' || |/' |
| |\/| ||  __||  _  | `--. \| | | ||    / |  __| |    /  / /_| ||  /| ||  /| ||  /| |
| |  | || |___| | | |/\__/ /| |_| || |\ \ | |___ | |\ \  \___  |\ |_/ /\ |_/ /\ |_/ /
\_|  |_/\____/\_| |_/\____/  \___/ \_| \_|\____/ \_| \_|     |_/ \___/  \___/  \___/ 
                                                                                     
=> https://github.com/jmmortega/Measurer4000");
            Console.WriteLine(@"Sample: Measurer4000 -json -complete SolutionPath.sln 
-json: To receive json file with measurer data 
-complete: To receive all data about measuring 
SolutionPath don't forget .sln extension!");
        }

        private static void JsonStats(Solution stats, bool complete)
        {
            var json = complete 
                ? JsonConvert.SerializeObject(stats) 
                : JsonConvert.SerializeObject(stats.Stats);

            var writer = new StreamWriter("stats.json");
            writer.WriteLine(json);
            writer.Close();
        }

        private static void PrintStats(Solution stats, bool complete) 
            => Console.WriteLine(complete ? stats.ToString() : stats.Stats.ToString());

        private static void InitServices()
        {
            var fileManagerService = new FileManagerService();
            ServiceLocator.Register<IFileManagerService>(fileManagerService);
            ServiceLocator.Register<IMeasurerService>(new MeasureService(fileManagerService));
        }
    }
}
