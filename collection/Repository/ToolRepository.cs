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
    /// Fills the Pagination model with all the parameters necessary.
    /// </summary>
    /// <param name="pageSize">The size the page should be.</param>
    /// <param name="currentPage">The page number it should return.</param>
    /// <returns>Only the with the Tool and Model data filled in, no other parameters like page size and table count.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Triggers if the size is larger then 1000 or if the size or page parameters are out of range.</exception>
    public async Task<IPagination> GetToolsPageAsync(IPagination toolPage)
    {
        // Math.Ceiling returns an integral value so casting it to an int shouldn't cause problems
        toolPage.LastPage = (int) Math.Ceiling((double)_context.Tools.Count() / toolPage.PageSize);
        if (toolPage.CurrentPage > toolPage.LastPage)
        {
            throw new ArgumentOutOfRangeException($"Invalid size of tool page. Largest tool page is {toolPage.LastPage}.");
        }

        IQueryable<Tool> dbQuery = _context.Tools;

        switch (toolPage.OrderBy.ToLower())
        {
            case "name":
                dbQuery = dbQuery.OrderBy(t => t.Name);
                break;
            case "brand":
                dbQuery = dbQuery.OrderBy(t => t.Brand);
                break;
            case "type":
                dbQuery = dbQuery.OrderBy(t => t.Type);
                break;
            case "electrical":
                dbQuery = dbQuery.OrderBy(t => t.Electrical);
                break;
            case "productcode":
                dbQuery = dbQuery.OrderBy(t => t.ProductCode);
                break;
            case "ean13":
                dbQuery = dbQuery.OrderBy(t => t.Ean13);
                break;
            default:
                dbQuery = dbQuery.OrderBy(t => t.Name);
                break;
        }
        
        toolPage.Data = await dbQuery.Skip((toolPage.CurrentPage - 1) * toolPage.PageSize).Take(toolPage.PageSize).Include("Brand").ToListAsync();
        return toolPage;
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
