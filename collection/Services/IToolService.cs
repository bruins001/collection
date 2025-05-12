using collection.Model;

namespace collection.Services;

public interface IToolService
{
    Task<IPagination?> GetToolsPage(int pageSize, int currentPage, string orderBy = "Name");
    Task<Tool?> GetToolById(int id);
}