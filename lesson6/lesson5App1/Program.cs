using System.IO.Compression;
namespace lesson5App1
{
    internal class Program
    {
        static async Task Main (string[] args)
        {
            const string sourceFileName = @"C:\Users\1\Desktop\HomeWorkCS\Arhiv.zip";
            const string destDirectName = @"C:\Users\1\Desktop\HomeWorkCS\lesson6\lesson5App1\pap";
            const string InfoFileName = @"C:\Users\1\Desktop\HomeWorkCS\lesson6\lesson5App1\Info.csv";
            const string SavePathName = @"C:\Users\1\Desktop\HomeWorkCS\lesson6\lesson5App1\Lesson12Homework.txt";

            // Check file and create
            if (!Directory.Exists(destDirectName))
            {
                Directory.CreateDirectory(destDirectName);
            }

            // Extract archive 
            try
            {
                ZipFile.ExtractToDirectory(sourceFileName, destDirectName);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            string[] files = Directory.GetFiles(destDirectName);
            string[] directories = Directory.GetDirectories(destDirectName);

            // Write info.csv
            try
            {
                using (StreamWriter writer = new StreamWriter(InfoFileName, false))
                {
                    // File info
                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string fileType = "File";
                        string fileName = fileInfo.Name;
                        string fileDate = fileInfo.LastWriteTime.ToString();
                        await writer.WriteLineAsync($"{fileType}\t{fileName}\t{fileDate}");
                    }
                    // Dir info
                    foreach (string directory in directories)
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                        string fileType = "Directory";
                        string directoryName = directoryInfo.Name;
                        string directoryDate = directoryInfo.LastWriteTime.ToString();
                        await writer.WriteLineAsync($"{fileType}\t{directoryName}\t{directoryDate}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error write info.csv: {ex.Message}");
            }

            //Delete directory
            Directory.Delete(destDirectName, true);

            
            //Save path info.csv
            try
            {
                using (StreamWriter writer = new StreamWriter(SavePathName))
                {
                    await writer.WriteLineAsync(InfoFileName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}