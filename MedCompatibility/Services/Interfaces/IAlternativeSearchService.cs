using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IAlternativeSearchService
{
    Task<List<medicine>> GetSafeAlternativesAsync(medicine targetDrug, user? patient, List<medicine> currentPrescriptions, bool onlyBelarusian, bool searchByAtc);
}
