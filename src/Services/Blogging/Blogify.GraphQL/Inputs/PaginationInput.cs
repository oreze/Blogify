namespace Blogify.GraphQL.Inputs;

public class PaginationInput
{
    public int Page { get; private set; }
    public int PageSize { get; private set; }

    public PaginationInput(int page, int pageSize)
    {
        Page = page >= 0 ? page : throw new ArgumentException("Page cannot be a negative value.");
        PageSize = pageSize > 0 ? pageSize : throw new ArgumentException("Page size cannot be zero or negative value.");
    }
}