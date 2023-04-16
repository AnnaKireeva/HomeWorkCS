namespace lesson5App2
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            const string SavePathName = @"C:\Users\1\Desktop\HomeWorkCS\lesson6\lesson5App1\Lesson12Homework.txt";
            string InfoFilePath = "";

            // Read path info.csv
            try
            {
                using (StreamReader reader = new(SavePathName))
                {
                    InfoFilePath =await reader.ReadLineAsync();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File Lesson12Homework.txt not found: {ex.Message}");
            }

            catch (IOException ex)
            {
                Console.WriteLine($"Error read Lesson12Homework.txt {ex.Message}");
            }

            List<FileData> data = new();

            // Read data 
            try
            {
                using (StreamReader reader = new(InfoFilePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] fields = line.Split('\t');
                        FileData item = new()
                        {
                            Type = fields[0],
                            Name = fields[1],
                            Date = DateTime.Parse(fields[2])
                        };
                        data.Add(item);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File Info.csv not found: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error read Info.csv {ex.Message}");
            }

            // Sort
            var sortedData = data.OrderBy(item => item.Date).ToList();
            // Write data
            foreach (FileData item in sortedData)
            {
                Console.WriteLine($"{item.Type} {item.Name} {item.Date}");
            }



            // Delete File
            File.Delete(SavePathName);
        }
    }

    // Class for data
    public class FileData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}