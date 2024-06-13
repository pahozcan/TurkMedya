// Models/PaginationViewModel.cs
public class PaginationViewModel<T>
{
    public List<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}

public class AnasayfaViewModel
{
    public List<DataItem> Data { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    //public int PaginationPageSize { get; set; }
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}
