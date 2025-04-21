using collection.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace collection.Repository;

public class ToolRepository : IToolRepository
{

    private readonly AppDbContext _context;
    
    public ToolRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Tool>> GetToolsPageAsync(int size, int page)
    {
        if (size < 1 || size > 1000)
        {
            throw new ArgumentOutOfRangeException("Tool size must be between 1 and 1000");
        }

        if (page < 1)
        {
            throw new ArgumentOutOfRangeException("Tool page must be greater than 0");
        }

        double numberOfPages = Math.Ceiling((double) _context.Tools.Count() / size);
        if (page > numberOfPages)
        {
            throw new ArgumentOutOfRangeException($"Invalid size of tool page. Largest tool page is {numberOfPages}.");
        }
        
        return await _context.Tools.OrderBy(tool => tool.Name).Skip((page - 1) * size).Take(size).Include("Brand").ToListAsync();
    }
    
    /// <summary>
    /// Gets the specific tool selected by the id you want with all the details.
    /// </summary>
    /// <param name="id">The id of the tool you want to find.</param>
    /// <returns>An instance of the model Tool.</returns>

    public async Task<Tool?> GetToolByIdAsync(int id)
    {
        return await _context.Tools.Include("Brand").SingleOrDefaultAsync(tool => tool.Id == id);
    }

    public async Task<Tool> InsertOneToolAsync(string type)
    {
        throw new NotImplementedException();
    }

    public async Task<Tool> UpdateOneToolAsync(IEnumerable<Tool> tools)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteOneToolAsync(IEnumerable<Tool> tools)
    {
        throw new NotImplementedException();
    }
}
