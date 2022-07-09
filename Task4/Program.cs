using FinalTask;

Console.WriteLine(Directory.GetCurrentDirectory());
DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
for (int i = 0; i < 3; i++)
     di = di.Parent;
Console.WriteLine(di.FullName);
string fileName = di.FullName + "\\Students.dat";
if (File.Exists(fileName))
{
    Person[] p = Person.GetData(fileName);
    if(p != null)
    {
        foreach (Person p2 in p)
        {
            Console.WriteLine(p2.Name);
        }
    }
}
else
{
    Console.WriteLine("File not found");
}

