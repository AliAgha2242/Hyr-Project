using HYR_Blog.CoreLayer.Dtos.CommentDtos;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto
{
    public class SingleProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Prise { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> ImagesName { get; set; }
        public List<ProductPropertyDto.ProductPropertyDto> Properties { get; set; }
        public float Score { get; set; }
        public List<CommentDto> Comments { get; set; }
        public int? Inventory { get; set; }
        public string? Description { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTAg { get; set; }
        public string? MetaTitle { get; set; }
        public string? KeyWorld { get; set; }
        public int Visit { get; set; }
        public string ProductCode { get; set; }
        public string Slug { get; set; }
    }
}
