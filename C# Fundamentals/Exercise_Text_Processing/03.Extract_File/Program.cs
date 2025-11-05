namespace _03.Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            int fileNameIndex = path.LastIndexOf('\\');
            int fileExtensionIndex = path.LastIndexOf('.');
            string fileName = path.Substring(fileNameIndex + 1, fileExtensionIndex - fileNameIndex - 1);

            string extension = path.Substring(fileExtensionIndex + 1, path.Length - fileExtensionIndex - 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
