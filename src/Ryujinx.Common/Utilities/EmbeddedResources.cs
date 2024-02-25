<<<<<<< HEAD
=======
using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ryujinx.Common
{
    public static class EmbeddedResources
    {
<<<<<<< HEAD
        private readonly static Assembly _resourceAssembly;

        static EmbeddedResources()
        {
            _resourceAssembly = Assembly.GetAssembly(typeof(EmbeddedResources));
=======
        private readonly static Assembly ResourceAssembly;

        static EmbeddedResources()
        {
            ResourceAssembly = Assembly.GetAssembly(typeof(EmbeddedResources));
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static byte[] Read(string filename)
        {
            var (assembly, path) = ResolveManifestPath(filename);

            return Read(assembly, path);
        }

        public static Task<byte[]> ReadAsync(string filename)
        {
            var (assembly, path) = ResolveManifestPath(filename);

            return ReadAsync(assembly, path);
        }

        public static byte[] Read(Assembly assembly, string filename)
        {
<<<<<<< HEAD
            using var stream = GetStream(assembly, filename);
            if (stream == null)
            {
                return null;
            }

            return StreamUtils.StreamToBytes(stream);
=======
            using (var stream = GetStream(assembly, filename))
            {
                if (stream == null)
                {
                    return null;
                }

                return StreamUtils.StreamToBytes(stream);
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public async static Task<byte[]> ReadAsync(Assembly assembly, string filename)
        {
<<<<<<< HEAD
            using var stream = GetStream(assembly, filename);
            if (stream == null)
            {
                return null;
            }

            return await StreamUtils.StreamToBytesAsync(stream);
=======
            using (var stream = GetStream(assembly, filename))
            {
                if (stream == null)
                {
                    return null;
                }

                return await StreamUtils.StreamToBytesAsync(stream);
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static string ReadAllText(string filename)
        {
            var (assembly, path) = ResolveManifestPath(filename);

            return ReadAllText(assembly, path);
        }

        public static Task<string> ReadAllTextAsync(string filename)
        {
            var (assembly, path) = ResolveManifestPath(filename);

            return ReadAllTextAsync(assembly, path);
        }

        public static string ReadAllText(Assembly assembly, string filename)
        {
<<<<<<< HEAD
            using var stream = GetStream(assembly, filename);
            if (stream == null)
            {
                return null;
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
=======
            using (var stream = GetStream(assembly, filename))
            {
                if (stream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public async static Task<string> ReadAllTextAsync(Assembly assembly, string filename)
        {
<<<<<<< HEAD
            using var stream = GetStream(assembly, filename);
            if (stream == null)
            {
                return null;
            }

            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
=======
            using (var stream = GetStream(assembly, filename))
            {
                if (stream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static Stream GetStream(string filename)
        {
            var (assembly, path) = ResolveManifestPath(filename);

            return GetStream(assembly, path);
        }

        public static Stream GetStream(Assembly assembly, string filename)
        {
<<<<<<< HEAD
            var @namespace = assembly.GetName().Name;
            var manifestUri = @namespace + "." + filename.Replace('/', '.');
=======
            var namespace_ = assembly.GetName().Name;
            var manifestUri = namespace_ + "." + filename.Replace('/', '.');
>>>>>>> 1ec71635b (sync with main branch)

            var stream = assembly.GetManifestResourceStream(manifestUri);

            return stream;
        }

        public static string[] GetAllAvailableResources(string path, string ext = "")
        {
            return ResolveManifestPath(path).Item1.GetManifestResourceNames()
                .Where(r => r.EndsWith(ext))
                .ToArray();
        }

        private static (Assembly, string) ResolveManifestPath(string filename)
        {
            var segments = filename.Split('/', 2, StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length >= 2)
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assembly.GetName().Name == segments[0])
                    {
                        return (assembly, segments[1]);
                    }
                }
            }

<<<<<<< HEAD
            return (_resourceAssembly, filename);
        }
    }
}
=======
            return (ResourceAssembly, filename);
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
