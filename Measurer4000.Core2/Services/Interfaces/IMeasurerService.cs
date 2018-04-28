using Measurer4000.Core.Models;

namespace Measurer4000.Core.Services.Interfaces
{
    public interface IMeasurerService
    {
        Solution GetProjects(string filePathToSolution);

        Solution Measure(Solution solutionProjects);
    }
}
