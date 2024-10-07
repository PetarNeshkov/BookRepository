using Microsoft.AspNetCore.Mvc;

namespace BookRepository.Api.Infrastructure.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<OkObjectResult> ToOkResult<T>(this Task<T> task)
            => new(await task);
    }
}
