using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendCalculationService.Services;

public class WorkbookStorageService
{
    private readonly string _storagePath = "UploadedFiles";

    public WorkbookStorageService()
    {
        Directory.CreateDirectory(_storagePath);
    }

    public async Task<string> SaveAsync(IFormFile file)
    {
        var filePath = Path.Combine(_storagePath, file.FileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
        return filePath;
    }

    public FileInfo GetFile(string filename)
    {
        return new FileInfo(Path.Combine(_storagePath, filename));
    }
}
