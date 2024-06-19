﻿namespace BLL.DTO;

public class ProductDTO
{
	public int Id { get; set; }
	public int Count { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
}
