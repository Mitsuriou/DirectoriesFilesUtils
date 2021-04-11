using System;
using System.IO;

namespace FileRenamer
{
    class MainFileRenamer
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
            var lFileName = System.IO.Path.GetFileNameWithoutExtension(aFilePath);
            var lFileExt = System.IO.Path.GetExtension(aFilePath);

            if (lFileName == aFind)
            {
                var lNewPath = System.IO.Path.GetDirectoryName(aFilePath) + System.IO.Path.DirectorySeparatorChar + aReplace + lFileExt;
                Console.WriteLine("-> Renaming \"{0}\" into \"{1}\"...", aFilePath, lNewPath);
                File.Move(aFilePath, lNewPath);
            }
        }
    }
}
