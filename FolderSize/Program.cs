using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var routeDirectory = args.Length == 1 ? args[0] : Directory.GetCurrentDirectory();

            Console.WriteLine($"Folder Size: {routeDirectory}");
            Console.WriteLine("**************");
            Console.WriteLine();

            foreach(string dir in Directory.GetDirectories(routeDirectory))
            {
                Console.WriteLine($"{TrimRouteFolder(dir, routeDirectory)}: {GetFolderSize(dir).ToString()}");
            }
        }

        static string TrimRouteFolder(string folder, string route)
        {
            return folder.Substring(route.Length + 1);
        }

        static long GetFolderSize(string folder)
        {
            long size = 0;
            foreach(var file in Directory.GetFiles(folder))
            {
                var fi = new FileInfo(file);
                size += fi.Length;
            }
            return size;
        }
    }
}
