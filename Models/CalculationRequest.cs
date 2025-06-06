namespace BackendCalculationService.Models;

public class CalculationRequest
{
    public string FilePath { get; set; }
    public Dictionary<string, object>? Inputs { get; set; }
}