using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Classes;
using KASHOP.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Classes
{
    public class BrandService : GenericService<BrandRequest,BrandResponse,Brand>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFileService _fileService;

        public BrandService(IBrandRepository brandRepository, IFileService fileService) : base(brandRepository)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateWithFile(BrandRequest brandRequest)
        {
            var brand = brandRequest.Adapt<Brand>();
            brand.CreatedAt = DateTime.UtcNow;

            if (brandRequest.Thumbnail != null)
            {
                var imagePath = await _fileService.UploadAsync(brandRequest.Thumbnail);
                brand.Thumbnail = imagePath;
            }

            return _brandRepository.Add(brand);
        }
    }
}
