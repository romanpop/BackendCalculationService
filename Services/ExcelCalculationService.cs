using OfficeOpenXml;
using System.Collections.Generic;

namespace BackendCalculationService.Services;

public class ExcelCalculationService
{
    public async Task<Dictionary<string, object>> CalculateAsync(string filePath, Dictionary<string, object>? inputs = null)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var package = new ExcelPackage(new FileInfo(filePath));
        var workbook = package.Workbook;
        var worksheet = workbook.Worksheets.First();

        if (inputs != null)
        {
            foreach (var kvp in inputs)
            {
                var namedRange = worksheet.Names[kvp.Key];
                if (namedRange != null)
                    namedRange.Value = kvp.Value;
            }
        }

        workbook.Calculate();

        var outputs = new Dictionary<string, object>();
        foreach (var named in worksheet.Names)
        {
            if (named.Value is double or string or bool)
            {
                outputs[named.Name] = named.Value;
            }
        }

        return outputs;
    }
}
