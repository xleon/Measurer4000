using System.IO;

namespace Measurer4000.Core.Services.Interfaces
{
    public interface IFileManagerService
    {
        Stream OpenRead(string filePath);
    }
}
