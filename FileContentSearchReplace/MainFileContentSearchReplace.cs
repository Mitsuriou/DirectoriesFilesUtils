using System;
using System.IO;

namespace FileContentSearchReplace
{
    class MainFileContentSearchReplace
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Error: the program needs three arguments in order to start.");
                Console.WriteLine("Press enter to close the program.");
                Console.ReadLine();
                System.Environment.Exit(-1);
            }

            var lDir = args[0].ToString();
            var lFind = args[1].ToString();
            var lReplace = args[2].ToString();

            if (Directory.Exists(lDir))
            {
                ProcessDirectory(lDir, lFind, lReplace);
            }
            else
            {
                Console.WriteLine("Error: \"{0}\" is not a valid root directory.", lDir);
            }

            Console.WriteLine("Process finished without error. Press enter to close...");
            Console.ReadLine();
        }

        public static void ProcessDirectory(string targetDirectory, string aFind, string aReplace)
        {
            // File
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName, aFind, aReplace);

            // Subdir
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, aFind, aReplace);
        }

        public static void ProcessFile(string aFilePath, string aFind, string aReplace)
        {
            if (File.Exists(aFilePath))
            {
                string lText = File.ReadAllText(aFilePath);
                lText = lText.Replace(aFind, aReplace);
                File.WriteAllText(aFilePath, lText);
                Console.WriteLine("Replaced \"{0}\" by \"{1}\" in the file \"{2}\"", aFind, aReplace, aFilePath);
            }
        }
    }
}
