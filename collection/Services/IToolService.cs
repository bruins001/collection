using collection.Model;

namespace collection.Services;

public interface IToolService
{
    Task<IEnumerable<Tool>?> GetToolsPage(int size, int page);
    Task<Tool?> GetToolById(int id);
}