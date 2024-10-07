using AutoMapper;

namespace BookRepository.Api.Infrastructure.AutoMapper
{
    public interface IMapExplicitly
    {
        void RegisterMappings(IProfileExpression configuration);
    }
}
