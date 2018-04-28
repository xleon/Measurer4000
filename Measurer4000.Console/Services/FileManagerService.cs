using System.IO;
using Measurer4000.Core.Services.Interfaces;

namespace Measurer4000.Command.Services
{
    public class FileManagerService : IFileManagerService
    {
        public Stream OpenRead(string filePath)
        {
            return File.OpenRead(filePath);
        }
    }
}
