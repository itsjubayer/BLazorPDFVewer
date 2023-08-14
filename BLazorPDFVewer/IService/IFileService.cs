using BLazorPDFVewer.Data;

namespace BLazorPDFVewer.IService
{
    public interface IFileService
    {
        List<FileClass>GetAllPDFs();
    }
}
