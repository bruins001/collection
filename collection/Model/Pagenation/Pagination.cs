namespace collection.Model;

public class Pagination: IPagination
{
    private int _pageSize;
    public required int CurrentPage { get; set; }

    public required int PageSize
    {
        get => _pageSize;
        set
        {
            if (!AvailablePageSize.Contains(value))
            {
                throw new ArgumentOutOfRangeException("PageSize may only be 10, 25, 50 and 100.");
            }
            
            _pageSize = value;
        }
    } // How large 1 page is
    public int[] AvailablePageSize { get; } = [10, 25, 50, 100];
    public int LastPage { get; set; }
    public required string OrderBy { get; set; } = "Name";
    public IEnumerable<Tool>? Data { get; set; }
}