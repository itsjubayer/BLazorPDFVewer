using BlazorInputFile;

namespace BLazorPDFVewer.IService
{
    public interface IFileUpload
    {
        Task Upload(IFileListEntry file);
    }
}
