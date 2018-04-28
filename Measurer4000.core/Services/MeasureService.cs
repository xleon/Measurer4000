using System.Threading.Tasks;
using Measurer4000.Core.Models;
using Measurer4000.Core.Services.Interfaces;
using Measurer4000.Core.Utils;

namespace Measurer4000.Core.Services
{
    public class MeasureService : IMeasurerService
    {
        private readonly IFileManagerService _fileManagerService;

        public MeasureService(IFileManagerService file) { _fileManagerService = file;}

        public Solution GetProjects(string filePathToSolution)
        {
            ProjectIdentificatorUtils.File = _fileManagerService;
            var projectLines = ProjectIdentificatorUtils.ReadProjectsLines(filePathToSolution);
            var solutionProjects = ProjectIdentificatorUtils.TranslateProjectsLinesToProjects(projectLines);
            Parallel.ForEach(solutionProjects, hit => {
                ProjectIdentificatorUtils.CompleteInfoForProject(hit, filePathToSolution);
            });
            return new Solution { Projects = solutionProjects };
        }

        public Solution Measure(Solution solution)
        {
            MeasureUtils.File = _fileManagerService;
            Parallel.ForEach(solution.Projects, project =>
            {
                Parallel.ForEach(project.Files, programmingFile =>
                {
                    programmingFile.Loc = MeasureUtils.CalculateLoc(programmingFile);
                });
            });

            solution.Stats = MeasureUtils.CalculateStats(solution);
            return solution;
        }
    }
}
