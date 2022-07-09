//Console.WriteLine("Please input file path:");
//string folderPath = Console.ReadLine();
string folderPath = "C:\\Users\\ygar\\source\\repos\\HW_FileIO\\testFolder";
//string folderPath = "C:\\Users\\ygar\\Downloads";
if (Directory.Exists(folderPath))
{
    long totalSize =0, newSize=0;
    int count_file=0;
    GetDirectoryInfo(folderPath, false,ref totalSize, ref newSize, ref count_file);
    Console.WriteLine($"Total size = {totalSize}");
    Console.WriteLine($"New size = {newSize}");
    Console.WriteLine($"File deleted = {count_file}");
}
else
    Console.WriteLine("Error folder path");



void GetDirectoryInfo(string folderPath, bool deleted, ref long totalSize, ref long  newSize, ref int count_file)
{
    string[] dirs = Directory.GetDirectories(folderPath);
    foreach (string dir in dirs)
        GetDirectoryInfo(dir, true, ref totalSize, ref newSize,ref count_file);
    //Console.WriteLine(folderPath + " files:");
    string[] files = Directory.GetFiles(folderPath);
    foreach (string file in files)
    {
        FileInfo fileInfo = new FileInfo(file);
        //Если изменить время на 0 то будут видны все файлы
        if (fileInfo.LastAccessTime.AddMinutes(1) < DateTime.Now)
        {
            try
            {
                totalSize += fileInfo.Length;
                count_file++;
                fileInfo.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                deleted = false;
            }
        }
        else
        {
            totalSize += fileInfo.Length;
            newSize += fileInfo.Length;
        }
    }
    if (Directory.GetFiles(folderPath).Length == 0 && Directory.GetDirectories(folderPath).Length == 0 && deleted)
    {
        try
        {
            Directory.Delete(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
