//string folderPath = "D:\\";
//string folderPath = "C:\\";

Console.WriteLine("Please input file path:");
string folderPath = Console.ReadLine();

if (Directory.Exists(folderPath))
{
    long size = GetDirectorySize(folderPath);
    Console.WriteLine($"Directory size = {size} bytes");
}
else
    Console.WriteLine("Error folder path");



long GetDirectorySize(string folderPath)
{
    long size = 0;
    try 
    { 
        //size = GetDirectorySize(folderPath);
        string[] dirs = Directory.GetDirectories(folderPath);
        foreach (string dir in dirs)
        {
            size += GetDirectorySize(dir);
        }

        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            size += fileInfo.Length;
        }
    }
    catch(Exception ex)
    { 
        Console.WriteLine(ex.Message); 
    }

    return size;
}
