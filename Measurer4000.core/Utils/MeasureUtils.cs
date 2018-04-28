using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Measurer4000.Core.Models;
using Measurer4000.Core.Services.Interfaces;

namespace Measurer4000.Core.Utils
{
	public static class MeasureUtils
    {
        public static IFileManagerService File;

        public static long CalculateLoc(ProgrammingFile programmingFile)
        {
            if(programmingFile.TypeFile == EnumTypeFile.Axml)
            {
                return CalculateLocAxml(programmingFile);
            }

            if(programmingFile.TypeFile == EnumTypeFile.CSharp)
            {
                return CalculateLocSharp(programmingFile);
            }

            if(programmingFile.TypeFile == EnumTypeFile.Xaml)
            {
                return CalculateLocXaml(programmingFile);
            }

            if (programmingFile.TypeFile == EnumTypeFile.Xib)
            {
                return CalculateLocXib(programmingFile);
            }

            Debug.WriteLine($"File not recognized {programmingFile.Path}");
            return 0;
        }

        private static long CalculateLocSharp(ProgrammingFile programmingFile)
        {
            StreamReader reader = null;
            var count = 0;
            var inComment = 0;

            try
            {
                reader = new StreamReader(File.OpenRead(programmingFile.Path));
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if(IsRealCodeCSharp(line.Trim(), ref inComment))
                    {
                        count++;
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                reader?.Dispose();
            }

            return count;
        }

        private static long CalculateLocXaml(ProgrammingFile programmingFile)
        {
            StreamReader reader = null;
            var count = 0;
            var inComment = 0;

            try
            {
                reader = new StreamReader(File.OpenRead(programmingFile.Path));
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    if (IsRealCodeXaml(line.Trim(), ref inComment))
                    {
                        count++;
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                if(reader != null)
                {
                    reader.Dispose();
                }
            }

            return count;
        
        }

        private static long CalculateLocAxml(ProgrammingFile programmingFile)
        {
            return CalculateLocXaml(programmingFile);
        }

        private static long CalculateLocXib(ProgrammingFile programmingFile)
        {
            return CalculateLocXaml(programmingFile);
        }

        private static bool IsRealCodeAxml(string line, ref int inComment)
        {
            return IsRealCodeXaml(line, ref inComment);
        }

        private static bool IsRealCodeXaml(string line, ref int inComment)
        {
            if(line.StartsWith("<!--") && line.EndsWith("-->"))
            {
                return false;
            }

            if(line.StartsWith("<!--"))
            {
                inComment++;
                return false;
            }

            if(line.EndsWith("-->"))
            {
                inComment--;
                return false;
            }

            return
                inComment == 0
                || line.Contains("/>")                
                || line.Contains(">");
        }

        private static bool IsRealCodeXib(string line, ref int inComment)
        {
            return IsRealCodeXaml(line, ref inComment);
        }

        private static bool IsRealCodeCSharp(string line, ref int inComment)
        {
            if(line.StartsWith("/*") && line.EndsWith("*/"))
            {
                return false;
            }

            if (line.StartsWith("/*"))
            {
                inComment++;
                return false;
            }

            if(line.EndsWith("*/"))
            {
                inComment--;
                return false;
            }

            return
                inComment == 0
            && !line.StartsWith("//")
            && (line.StartsWith("if")
            || line.StartsWith("else if")
            || line.StartsWith("using")
            || line.Contains(";")
            || line.StartsWith("public")
            || line.StartsWith("private")
            || line.StartsWith("protected"));
        } 

        public static CodeStats CalculateStats(Solution currentSolution)
        {
			var files = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.Android).SelectMany(x => x.Files);

			foreach (var item in files)
			{
				Debug.WriteLine($"file: {item.Name}");
			}

			var stats = new CodeStats
			{
				ShareCodeInAndroid = CalculateShareCodePerPlaform(currentSolution, EnumPlatform.Android),
                
				AndroidFiles = files.Count(),
				TotalLinesInAndroid = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.Android).SelectMany(x => x.Files).Sum(x => x.Loc),

				ShareCodeIniOs = CalculateShareCodePerPlaform(currentSolution, EnumPlatform.IOs),
				IOsFiles = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.IOs).SelectMany(x => x.Files).Count(),
				TotalLinesIniOs = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.IOs).SelectMany(x => x.Files).Sum(x => x.Loc),

				ShareCodeInUwp = CalculateShareCodePerPlaform(currentSolution, EnumPlatform.Uwp),
				UwpFiles = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.Uwp).SelectMany(x => x.Files).Count(),
				TotalLinesInUwp = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.Uwp).SelectMany(x => x.Files).Sum(x => x.Loc),

                AmountOfFiles = currentSolution.Projects.SelectMany(p => p.Files).Count(),
                CodeFiles = currentSolution.Projects.SelectMany(x => x.Files).Count(x => x.IsUserInterface == false),
                UiFiles = currentSolution.Projects.SelectMany(x => x.Files).Count(x => x.IsUserInterface),
                TotalLinesOfCode = currentSolution.Projects.SelectMany(x => x.Files).Where(x => x.IsUserInterface == false).Sum(x => x.Loc),
                TotalLinesOfUi = currentSolution.Projects.SelectMany(x => x.Files).Where(x => x.IsUserInterface).Sum(x => x.Loc),
                TotalLinesCore = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.Core).SelectMany(x => x.Files).Sum(x => x.Loc)            
            };

            stats.IOsSpecificCode = Math.Round(100 - stats.ShareCodeIniOs, 2);
            stats.AndroidSpecificCode = Math.Round(100 - stats.ShareCodeInAndroid, 2);
			stats.UwpSpecificCode = Math.Round(100 - stats.ShareCodeInUwp, 2);

            return stats;
        }

		private static double CalculateShareCodePerPlaform(Solution currentSolution, EnumPlatform selectedPlatform)
		{
			var totalCoreLoc = currentSolution.Projects.Where(x => x.Platform == EnumPlatform.Core).SelectMany(x => x.Files).Where(x => x.IsUserInterface == false).Sum(x => x.Loc);
			var platformSpecificLoc = currentSolution.Projects.Where(x => x.Platform == selectedPlatform).SelectMany(x => x.Files).Where(x => x.IsUserInterface == false).Sum(x => x.Loc);

			return Math.Round(((double) totalCoreLoc / (platformSpecificLoc + totalCoreLoc)) * 100, 2);
		}
    }
}
