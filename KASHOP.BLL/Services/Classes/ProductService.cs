using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Classes
{
    public class ProductService : GenericService<ProductRequest,ProductResponse,Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository productRepository, IFileService fileService) : base(productRepository)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateWithFile(ProductRequest productRequest)
        {
            var product = productRequest.Adapt<Product>();
            product.CreatedAt = DateTime.UtcNow;

            if (productRequest.Thumbnail != null)
            {
                var imagePath = await _fileService.UploadAsync(productRequest.Thumbnail);
                product.Thumbnail = imagePath;
            }

            return _productRepository.Add(product);
        }
    }
}
