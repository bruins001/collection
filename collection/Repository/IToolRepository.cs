using collection.Model;

namespace collection.Repository;

public interface IToolRepository
{
    Task<IEnumerable<Tool>> GetToolsPageAsync(int size, int page);
    Task<Tool?> GetToolByIdAsync(int id);
    Task<Tool> InsertOneToolAsync(string type);
    Task<Tool> UpdateOneToolAsync(IEnumerable<Tool> tools);
    Task DeleteOneToolAsync(IEnumerable<Tool> tools);
}