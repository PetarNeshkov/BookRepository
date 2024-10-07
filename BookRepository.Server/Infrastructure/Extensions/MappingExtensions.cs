using BookRepository.Api.Infrastructure.AutoMapper;
using System.Collections;

namespace BookRepository.Api.Infrastructure.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination Map<TDestination>(this object item)
            => AutoMapperSingleton.Instance.Mapper.Map<TDestination>(item);

        public static IQueryable<TDestination> MapCollection<TDestination>(
        this IQueryable queryable,
        object parameters = null!)
            => AutoMapperSingleton.Instance.Mapper.ProjectTo<TDestination>(queryable, parameters);
    }
}
