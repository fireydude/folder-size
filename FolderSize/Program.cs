namespace FolderSize
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var routeDirectory = args.Length == 1 ? args[0] : Directory.GetCurrentDirectory();

            var calculator = new SizeCalculator(routeDirectory);
            calculator.PrintOutput();
        }
    }
}