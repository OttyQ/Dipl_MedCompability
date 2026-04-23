using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IPdfReportService
{
    Task<byte[]> GenerateCrossAnalysisReportAsync(string doctorName, List<medicine> checkedDrugs, List<interaction> interactions);
    Task<byte[]> GeneratePatientInteractionReportAsync(string doctorName, user patient, List<interaction> interactions, List<medicine> pastConflictingDrugs);
}
