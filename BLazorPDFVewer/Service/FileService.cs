using BLazorPDFVewer.Data;
using BLazorPDFVewer.IService;

namespace BLazorPDFVewer.Service
{
    public class FileService:IFileService
    {
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment =null;

        public FileService(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<FileClass> GetAllPDFs() 
        { 
            List<FileClass> files = new List<FileClass>();
            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";
            int nFileId = 1;
            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                files.Add(new FileClass()
                {
                    FileId = nFileId++,
                    Name = Path.GetFileName(pdfPath),
                    Path=pdfPath
                });
            }
            return files;
        }



    }
}
