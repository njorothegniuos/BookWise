using System.Reflection;

namespace BookWise.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly Instance = typeof(AssemblyReference).Assembly;
    }
}
