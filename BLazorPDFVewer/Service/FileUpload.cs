using BlazorInputFile;
using BLazorPDFVewer.IService;
using System.IO;

namespace BLazorPDFVewer.Service
{
    public class FileUpload : IFileUpload
    {
        [Obsolete]
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment = null;
        public FileUpload(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task Upload(IFileListEntry file)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "files", file.Name);
            var memoryStream = new MemoryStream();

            await file.Data.CopyToAsync(memoryStream);

            using(FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}
