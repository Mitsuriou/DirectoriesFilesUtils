using System;
using System.IO;

namespace FilePrepender
{
    class MainFilePrepender
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error: the program needs two arguments in order to start:");
                Console.WriteLine("[0]: root directory");
                Console.WriteLine("[1]: string to prepend to every file");
                Console.WriteLine("Press enter to close the program.");
                Console.ReadLine();
                System.Environment.Exit(-1);
            }

            var lDir = args[0].ToString();
            var lPrepend = args[1].ToString();

            Console.WriteLine("The program will prepend XML and OSP files' names under \"{0}\" with \"{0}\". Press enter to start...", lDir, lPrepend);
            Console.ReadLine();

            if (Directory.Exists(lDir))
            {
                ProcessDirectory(lDir, lPrepend);
            }
            else
            {
                Console.WriteLine("Error: \"{0}\" is not a valid root directory.", lDir);
            }

            Console.WriteLine("Process finished without error. Press enter to close...");
            Console.ReadLine();
        }

        public static void ProcessDirectory(string targetDirectory, string aPrepend)
        {
            // File
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName, aPrepend);

            // Subdir
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, aPrepend);
        }

        public static void ProcessFile(string aFilePath, string aPrepend)
        {
            var lFileExt = System.IO.Path.GetExtension(aFilePath);

            if (lFileExt == ".xml" || lFileExt == ".osp")
            {
                var lFileName = System.IO.Path.GetFileName(aFilePath);
                var lNewPath = System.IO.Path.GetDirectoryName(aFilePath) + System.IO.Path.DirectorySeparatorChar + aPrepend + lFileName;
                Console.WriteLine("-> Prepending \"{0}\"...", aFilePath);
                File.Move(aFilePath, lNewPath);
                Console.WriteLine("-> Prepended \"{0}\".", aFilePath);
            }
        }
    }
}
