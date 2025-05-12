namespace collection.Model;

public interface IPagination
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; } // How large 1 page is
    public int LastPage { get; set; }
    public string OrderBy { get; set; }
    public int[] AvailablePageSize { get; }
    public IEnumerable<Tool>? Data { get; set; }
}