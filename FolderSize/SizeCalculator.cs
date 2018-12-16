using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SizeCalculator
{
    private const string FILE_KEY = "(files)";
    private readonly string routeDirectory;

    public SizeCalculator(string routeDirectory)
    {
        this.routeDirectory = routeDirectory;
    }

    public void PrintOutput()
    {
        Console.WriteLine("**************");
        Console.WriteLine($"Folder Size: {routeDirectory}");
        Console.WriteLine("measured in bytes");

        var sizeDictionary = new Dictionary<string, long>();
        sizeDictionary.Add(FILE_KEY, GetFolderSize(routeDirectory, false));
        foreach (string dir in Directory.GetDirectories(routeDirectory))
        {
            var sizeKb = GetFolderSize(dir);
            var folder = TrimRouteFolder(dir, routeDirectory);
            sizeDictionary.Add(folder, sizeKb);
            Console.Write(".");
        }
        Console.Clear();
        Console.WriteLine($"Folder Size: {routeDirectory}");

        var maxFolderLength = sizeDictionary.Keys.Max(k => k.Length).ToString();
        var rowFormat = "{0," + maxFolderLength + "} {1,15:N0}";
        Console.WriteLine();
        Console.WriteLine("Total size:");
        Console.WriteLine(
            string.Format(rowFormat, "files and folders", sizeDictionary.Values.Sum())
            );
        Console.WriteLine();

        var filesValue = sizeDictionary.Single(i => i.Key == FILE_KEY).Value;
        Console.WriteLine("Files:"
        );
        Console.WriteLine(
            string.Format(rowFormat, "all files", filesValue)
        );

        Console.WriteLine("Subfolders:");
        foreach (var pair in sizeDictionary.Where(i => i.Key != FILE_KEY).OrderByDescending(i => i.Value))
        {
            Console.WriteLine(
                String.Format(rowFormat, pair.Key, pair.Value)
            );
        }
    }

    string TrimRouteFolder(string folder, string route)
    {
        return folder.Substring(route.Length + 1);
    }

    long GetFolderSize(string folder, bool includeSubFolders = true)
    {
        long size = 0;
        var searchOption = includeSubFolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        foreach (var file in Directory.GetFiles(folder, "", searchOption))
        {
            var fi = new FileInfo(file);
            size += fi.Length;
        }
        return size;
    }
}