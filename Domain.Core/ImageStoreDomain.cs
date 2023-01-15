using Domain.Interface;
using Entity;
using Infrastructure.Interface;


namespace Domain.Core
{
    public class ImageStoreDomain : IImageStoreDomain
    {
        private readonly IImageStore _repository;
        public ImageStoreDomain(IImageStore repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateImageStoreAsync(ImageStore image)
        {
            return await _repository.CreateImageStoreAsync(image);
        }

        public async Task<IEnumerable<ImageStore>> GetImageStoresByProperIdAsync(string propertyId)
        {
            return await _repository.GetImageStoresByProperIdAsync(propertyId);
        }
    }
}
