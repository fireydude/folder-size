Simple .NET 8 Console Application to list the size of each subfolder in a directory

 > Initially this was created as an alternative to [TreeSize](https://www.jam-software.com/treesize) because it which is not available on Mac.  There are various built in tools for calculating folder sizes on Mac and Linux so this is more of a coding exercise.

## Install
You can build this from source and add it to your command line environment.

### Windows
Execute this command from the project folder to create an executable
  - `dotnet publish -o "C:\FolderSize" -c Release`

Then add `C:\FolderSize` to your Path Environment variable.

### MacOS
Execute this command from the project folder to create an executable
  - `dotnet publish -o /usr/local/bin/folder-size -c Release`

You should be able run `FolderSize`from any folder after you have restarted your terminal.