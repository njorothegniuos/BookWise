using System.Reflection;

namespace BookWise.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly Instance = typeof(AssemblyReference).Assembly;
    }
}