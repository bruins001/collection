using collection.Model;
using Microsoft.EntityFrameworkCore;

namespace collection.Repository;

public class ToolRepository : IToolRepository
{

    private readonly AppDbContext _context;
    
    public ToolRepository(AppDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Makes a page with the size and page parameters. The page is based on the Tool and Brand model.
    /// The page does only contain the data based on the Tool and Brand model. No page size or table count for example. 
    /// </summary>
    /// <param name="size">The size the page should be.</param>
    /// <param name="page">The page number it should return.</param>
    /// <returns>Only the with the Tool and Model data filled in, no other parameters like page size and table count.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Triggers if the size is larger then 1000 or if the size or page parameters are out of range.</exception>
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
