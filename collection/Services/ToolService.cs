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
    /// Gets the toolpage from the Tool repository and returns it.
    /// </summary>
    /// <param name="size">The size of the page</param>
    /// <param name="page">The page number</param>
    /// <returns>The page filled with instances of the Tool and Brand model. No data about the page like last page.</returns>
    public async Task<IEnumerable<Tool>?> GetToolsPage(int size, int page)
    {
        IEnumerable<Tool>? tools = null;
        
        try
        {
            tools = await _toolRepository.GetToolsPageAsync(size, page);
        }
        // Tool should stay null but request should not crash
        catch
        {
            // ignored
        }

        return tools;
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