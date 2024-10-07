using BookRepository.Api.Infrastructure.AutoMapper;
using System.Collections;

namespace BookRepository.Api.Infrastructure.Extensions
{
    public static class MappingExtensions
    {
        public static IQueryable<TDestination> MapCollection<TDestination>(
        this IQueryable queryable,
        object parameters = null!)
            => AutoMapperSingleton.Instance.Mapper.ProjectTo<TDestination>(queryable, parameters);

        public static async Task<IEnumerable<TDestination>> MapCollection<TDestination>(this Task task)
        {
            var taskWithResult = task as dynamic;

            if (!task.HasEnumerableResult())
            {
                var destination = AutoMapperSingleton.Instance.Mapper.Map<TDestination>(await taskWithResult);

                return [destination];
            }

            return AutoMapperSingleton.Instance.Mapper.Map<IEnumerable<TDestination>>(await taskWithResult);
        }

        private static bool HasEnumerableResult(this Task task)
        {
            var type = task.GetType();
            if (!type.IsGenericType)
            {
                throw new InvalidOperationException("Cannot map a void Task.");
            }

            var genericArguments = type.GetGenericArguments();

            return typeof(IEnumerable).IsAssignableFrom(genericArguments.First());
        }
    }
}
