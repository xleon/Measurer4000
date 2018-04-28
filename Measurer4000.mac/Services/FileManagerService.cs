using System.IO;
using Foundation;
using Measurer4000.Core.Services.Interfaces;

namespace Measurer4000.mac.Services
{
    class FileManagerService : IFileManagerService
    {
        public Stream OpenRead(string filePath)
        {
			var path = filePath.Replace("\\", "/");
            return NSFileHandle.OpenRead(path).ReadDataToEndOfFile().AsStream();
        }
    }
}
