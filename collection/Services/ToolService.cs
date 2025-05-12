using System.Net;
using collection.Model;
using collection.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace collection.Services;

public class ToolService : IToolService
{
    private readonly IToolRepository _toolRepository;
    
    public ToolService(IToolRepository toolRepository)
    {
        _toolRepository = toolRepository;
    }

    /// <summary>
    /// Validates what the parameters as far as it can without the database.
    /// Gets the toolpage from the Tool repository and returns it.
    /// </summary>
    /// <param name="pageSize">The size of the currentpage</param>
    /// <param name="currentpage">The currentpage number</param>
    /// <returns>The currentpage filled with instances of the Tool and Brand model. No data about the currentpage like last currentpage.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Triggers if the size is not 10, 25, 50 or 100 and if currentPage is smallar than 0.</exception>
    public async Task<IPagination?> GetToolsPage(int pageSize, int currentPage, string orderBy = "Name")
    {
        IPagination toolPage = new Pagination()
        {
            CurrentPage = currentPage,
            PageSize = pageSize,
            OrderBy = orderBy.ToLower(),
        };
        
        if (!toolPage.AvailablePageSize.Contains(pageSize))
        {
            throw new ArgumentOutOfRangeException("Page size may only be 10, 25, 50, 100.");
        } 
        else if (toolPage.CurrentPage < 1)
        {
            throw new ArgumentOutOfRangeException("Tool currentpage must be greater than 0.");
        }
        
        try
        {
            toolPage = await _toolRepository.GetToolsPageAsync(toolPage);
        }
        // Tool should stay null but request should not crash
        catch
        {
            return null;
        }

        return toolPage;
    }
    
    /// <summary>
    /// Gets the specific tool selected by the id you want with all the details.
    /// </summary>
    /// <param name="id">The id of the tool you want to find.</param>
    /// <returns>An instance of the model Tool.</returns>
    public async Task<Tool?> GetToolById(int id)
    {
        Tool? tool = null;
        
        try
        {
            tool = await _toolRepository.GetToolByIdAsync(id);
        }
        // Tool should stay null but request should not crash
        catch
        {
            // ignored
        }

        return tool;
    }
}