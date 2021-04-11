using System;
using System.IO;

namespace FileDescriber
{
    class MainFileDesccriber
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Error: the program needs one argument in order to start.");
                Console.WriteLine("Press enter to close the program.");
                Console.ReadLine();
                System.Environment.Exit(-1);
            }

            var lDir = args[0].ToString();

            if (Directory.Exists(lDir))
            {
                ProcessDirectory(lDir);
            }
            else
            {
                Console.WriteLine("Error: \"{0}\" is not a valid root directory.", lDir);
            }

            Console.WriteLine("Process finished without error. Press enter to close...");
            Console.ReadLine();
        }

        public static void ProcessDirectory(string targetDirectory)
        {
            // File
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Subdir
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string aFilePath)
        {
            aFilePath = aFilePath.Replace("D:\\MFBO\\Mitsuriou Follower Bodies Overhaul", "C:\\Users\\Nemesis\\AppData\\Local\\Temp\\NexusModManager\\zxh5nshx.jmd");
            Console.ForegroundColor = (aFilePath.Length >= 232) ? ConsoleColor.Red : ConsoleColor.White;
            Console.WriteLine(aFilePath);
        }
    }
}
