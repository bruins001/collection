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

    public async Task<IEnumerable<Tool>> GetToolsPage(int size, int page)
    {
        IEnumerable<Tool>? tools = null;
        
        try
        {
            tools = await _toolRepository.GetToolsPageAsync(size, page);
        }
        // Tool should stay null but request should not crash
        catch (Exception _)
        { }

        return tools;
    }
}