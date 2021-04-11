using System;
using System.IO;

namespace FileSearcher
{
    class MainFileSearcher
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error: the program needs two arguments in order to start.");
                Console.WriteLine("Press enter to close the program.");
                Console.ReadLine();
                System.Environment.Exit(-1);
            }

            var lDir = args[0].ToString();
            var lExtension = args[1].ToString();

            if (Directory.Exists(lDir))
            {
                ProcessDirectory(lDir, lExtension);
            }
            else
            {
                Console.WriteLine("Error: \"{0}\" is not a valid root directory.", lDir);
            }

            Console.WriteLine("Process finished without error. Press enter to close...");
            Console.ReadLine();
        }

        public static void ProcessDirectory(string targetDirectory, string aExtension)
        {
            // File
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName, aExtension);

            // Subdir
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, aExtension);
        }

        public static void ProcessFile(string aFilePath, string aExtension)
        {
            if (System.IO.Path.GetExtension(aFilePath) == aExtension)
            {
                var lFileName = System.IO.Path.GetFileNameWithoutExtension(aFilePath);
                var lFileSize = new System.IO.FileInfo(aFilePath).Length;

                if (lFileSize != 87069 && lFileSize > 0 && lFileName != "skeleton_female")
                {
                    Console.WriteLine("[skeleton_female.nif] " + aFilePath);
                    //File.Copy("D:\\Users\\Athena\\Desktop\\skeleton_female.nif", aFilePath, true);
                }
            }
        }
    }
}
