using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using FluentValidation;
using Mapster;

namespace BLL.Services.Implementations;

public class ProductService : IProductService
{
	private readonly IProductRepository _productRepository;
	private readonly IValidator<ProductRequestDTO> _validator;
    public ProductService(IProductRepository productRepository, IValidator<ProductRequestDTO> validator)
    {
        _productRepository = productRepository;
		_validator = validator;
    }
    public async Task<ProductResponseDTO> CreateAsync(ProductRequestDTO product)
	{
		var validationResult = await _validator.ValidateAsync(product);

		if (validationResult.IsValid)
		{
			throw new Exceptions.ValidationException("Validation error");
		}

		var mappedProduct = product.Adapt<Product>();

		_productRepository.CreateAsync(mappedProduct);

		var response = mappedProduct.Adapt<ProductResponseDTO>();
		return response;
	}

	public async Task DeleteAsync(int id)
	{
		var product = await _productRepository.GetByIdAsync(id);

		if (product == null)
		{
			throw new NotFoundException($"Product with id {id} not found");
		}

		_productRepository.DeleteAsync(product);
	}

	public async Task<ProductResponseDTO> GetByIdAsync(int id)
	{
		var product = await _productRepository.GetByIdAsync(id);

		if (product == null)
		{
			throw new NotFoundException($"Product with id {id} not found");
		}

		return product.Adapt<ProductResponseDTO>();
	}

	public async Task UpdateAsync(int id, ProductRequestDTO product)
	{
		var validationResult = await _validator.ValidateAsync(product);

		if (validationResult.IsValid)
		{
			throw new Exceptions.ValidationException("Validation error");
		}

		var productExist = await _productRepository.GetByIdAsync(id);

		if (product == null)
		{
			throw new NotFoundException($"Product with id {id} not found");
		}

		_productRepository.UpdateAsync(productExist);
	}
}
