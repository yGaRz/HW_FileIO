//Console.WriteLine("Please input file path:");
//string folderPath = Console.ReadLine();
string folderPath = "C:\\Users\\ygar\\source\\repos\\HW_FileIO\\testFolder";
//string folderPath = "C:\\Users\\ygar\\Downloads";
if (Directory.Exists(folderPath))
{
   GetDirectoryInfo(folderPath, false);
}
else
    Console.WriteLine("Error folder path");



void GetDirectoryInfo(string folderPath,bool deleted)
{
    string[] dirs = Directory.GetDirectories(folderPath);
    foreach (string dir in dirs)
        GetDirectoryInfo(dir, true);
    //Console.WriteLine(folderPath + " files:");
    string[] files = Directory.GetFiles(folderPath);
    foreach (string file in files)
    {
        FileInfo fileInfo = new FileInfo(file);
        //Если изменить время на 0 то будут видны все файлы
        if (fileInfo.LastAccessTime.AddMinutes(30) < DateTime.Now)
        {
            //Console.WriteLine(file);
            try
            {
                fileInfo.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                deleted = false;
            }
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
