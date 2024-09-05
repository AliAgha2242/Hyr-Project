﻿using Microsoft.AspNetCore.Http;

namespace HYR_Blog.CoreLayer.Dtos.ProductDto;

public class ProductDto
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Prise { get; set; }
    public int PriseByDiscount { get; set; }
    public int? Weight { get; set; }
    public bool IsSpecial { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaTag { get; set; }
    public string? MetaDescription { get; set; }
    public string? KeyWorld { get; set; }
    public string? RelationKey { get; set; }
    public List<ProductPropertyDto.ProductPropertyDto> ProductPropertyDtos { get; set; }
    public string CategoryName { get; set; }
    public int? Inventory { get; set; }
    public List<ImageProductDto.ImageProductDto> Images { get; set; }
}