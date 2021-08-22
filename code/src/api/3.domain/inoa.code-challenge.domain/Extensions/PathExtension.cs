using System;
using System.IO;
using System.Reflection;

namespace inoa.code_challenge.domain.Extensions
{
    public static class PathExtension
    {
        public static string GetDirectoryPath(this Assembly assembly)
        {
            string filePath = new Uri(assembly.CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);            
        }
    }
}