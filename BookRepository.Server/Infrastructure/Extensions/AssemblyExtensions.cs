using System.Reflection;
using System.Text.RegularExpressions;

namespace BookRepository.Api.Infrastructure.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Assembly> GetAllReferencedAssembliesWhereFullNameMatchesPatterns(
      this Assembly assembly,
      params string[] regexPatterns)
        {
            var returnAssemblies = new List<Assembly>();
            var loadedAssemblies = new HashSet<string>();
            var assembliesToCheck = new Queue<Assembly>();

            assembliesToCheck.Enqueue(assembly);

            var assemblyPrefix = assembly.GetPrefix();

            while (assembliesToCheck.Any())
            {
                var assemblyToCheck = assembliesToCheck.Dequeue();

                var filteredAssemblyNames = assemblyToCheck.GetReferencedAssemblies()
                                            .Where(x => x.FullName.StartsWith(assemblyPrefix));

                foreach (var reference in filteredAssemblyNames)
                {
                    if (loadedAssemblies.Contains(reference.FullName))
                    {
                        continue;
                    }

                    var loadedAssembly = Assembly.Load(reference);
                    assembliesToCheck.Enqueue(loadedAssembly);
                    loadedAssemblies.Add(reference.FullName);
                    returnAssemblies.Add(loadedAssembly);
                }
            }

            var regexes = regexPatterns.Select(rp => new Regex(rp));

            return returnAssemblies
                .Where(x => regexes.Any(r => x.FullName != null && r.IsMatch(x.FullName)));
        }

        public static string GetPrefix(this Assembly assembly)
            => assembly.GetName()?.Name?.Split(".").FirstOrDefault()
               ?? throw new ArgumentException("Cannot get assembly prefix.", nameof(assembly));
    }
}
