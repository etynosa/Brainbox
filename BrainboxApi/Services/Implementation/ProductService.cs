using AutoMapper;
using BrainboxApi.DTOs;
using BrainboxApi.Entity;
using BrainboxApi.Helpers;
using BrainboxApi.Repository.IRepository;
using BrainboxApi.Services.Interface;

namespace BrainboxApi.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<APIResponse> GetAllProducts()
        {
          var products = await _productRepository.GetAllProducts();
            if (products !=null)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, products, MessageConstants.FetchSuccessMessage, products.Count());
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.NotFound, null, MessageConstants.NotFoundMessage);
        }

        public async Task<APIResponse> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product != null)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, product,MessageConstants.FetchSuccessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.NotFound, null, MessageConstants.NotFoundMessage);
        }

        public async Task<APIResponse> AddProduct(AddProductDto model)
        {

            var product = _mapper.Map<Product>(model);
            var result = await _productRepository.AddProduct(product);
            if (result > 0)
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.Created, product, MessageConstants.CreateSuccessMessage);
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.InternalServerError, null, MessageConstants.CreateFailureMessage);
        }

        public async Task<APIResponse> UpdateProduct(UpdateProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            var existingProduct = await _productRepository.GetProductById(product.Id);
            if (existingProduct == null)
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.NotFound, null, MessageConstants.NotFoundMessage);
            await _productRepository.UpdateProduct(product);
            return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, product, MessageConstants.UpdateSuccessMessage);
        }

        public async Task<APIResponse> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, null, MessageConstants.DeleteSuceessMessage);
        }

        public async Task<APIResponse> SearchProducts(ProductSearchDto model)
        {
            var products = await _productRepository.SearchProducts(model);
            if (products != null && products.Any())
                return APIResponse.GetSuccessMessage(System.Net.HttpStatusCode.OK, products, MessageConstants.FetchSuccessMessage, products.Count());
            else
                return APIResponse.GetFailureMessage(System.Net.HttpStatusCode.NotFound, null, MessageConstants.NotFoundMessage);
        }
    }
}
