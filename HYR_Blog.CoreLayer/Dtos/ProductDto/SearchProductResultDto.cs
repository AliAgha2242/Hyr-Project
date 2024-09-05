namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class SearchProductResultDto
    {
        public List<SearchFilterProductDto> Products { get; set; }
        public List<ReLatedProductDto> RelatedProduct { get; set; }
        public PaginationResult Pagination { get; set; }
    }
}
