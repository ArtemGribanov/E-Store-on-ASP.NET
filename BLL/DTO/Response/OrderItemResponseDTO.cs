using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Response;

public class OrderItemResponseDTO
{
	public int OrderId { get; set; }
	public OrderResponseDTO Order { get; set; }
	public int ProductId { get; set; }
	public ProductResponseDTO Product { get; set; }
	public int Count { get; set; }
}
