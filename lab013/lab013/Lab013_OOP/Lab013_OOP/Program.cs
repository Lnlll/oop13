using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lab013_OOP
{
    class SEDlog
    {
        public static string Way = "SEDlogfile.txt";
        public static bool CreateFile()
        {

            StreamWriter sw = new StreamWriter(Way, true, System.Text.Encoding.Default);
            using (sw)
            {
                sw.WriteLine(DateTime.Now + " - время создания. ");
                sw.WriteLine(Way + " -путь.");

            }
            
            return true;

        }
        public static bool CloseFile()
        {
            StreamWriter sw = new StreamWriter(Way, true, System.Text.Encoding.Default);
            sw.WriteLine("Конец работы: "+ DateTime.Now);
            sw.Close();
            return true;
        }
        public static bool CreateFile(string Way)
        {

            StreamWriter sw = new StreamWriter(Way,false, System.Text.Encoding.Default);
            using (sw)
            {
                sw.WriteLine(DateTime.Now + " - время создания. ");
                                
            }
                
                return true;
            
        }
        public static bool WriteInFile(string s)
        {
            StreamWriter sw = new StreamWriter(Way, true, System.Text.Encoding.Default);
            using (sw)
            {
                sw.WriteLine(s);
            }

            return true;
        }
        public static bool WriteInFile(object s,string Way)
        {
            StreamWriter sw = new StreamWriter(Way, true, System.Text.Encoding.Default);
            using (sw)
            {
                sw.WriteLine(s);
            }
            
            return true;
        }
     
    }
    class SEDdiskinfo
    {
      
        
        public static void GetInfo()
        {
            SEDlog.CreateFile("SEDdickinfo.txt");
            DriveInfo[] drive = DriveInfo.GetDrives();
            foreach (DriveInfo drives in drive)
            {
                
                
                    SEDlog.WriteInFile("Имя диска: " + drives.Name, "SEDdickinfo.txt");
                    SEDlog.WriteInFile("Свободное место: " + drives.TotalFreeSpace, "SEDdickinfo.txt");
                    SEDlog.WriteInFile("Все место: " + drives.TotalSize, "SEDdickinfo.txt");
                    SEDlog.WriteInFile("Доступное свободное место: " + drives.AvailableFreeSpace, "SEDdickinfo.txt");
                    SEDlog.WriteInFile("Метка тома диска: " + drives.VolumeLabel, "SEDdickinfo.txt");
                    

            }
            SEDlog.WriteInFile("  ", "SEDdickinfo.txt");
        }
            
    }

    class SEDfileinfo
    {
        static FileInfo fi;
        public static void fileinfo(string name)
        {
            fi = new FileInfo(name);
            SEDlog.WriteInFile(" Полный путь: \t"+fi.DirectoryName,"SEDfileinfo.txt");
            SEDlog.WriteInFile(" Расширение: \t"+fi.Extension, "SEDfileinfo.txt");
            SEDlog.WriteInFile(" Полный путь к файлу: \t"+fi.FullName, "SEDfileinfo.txt");
            SEDlog.WriteInFile(" Последний доступ к файлу: \t"+fi.LastAccessTime, "SEDfileinfo.txt");
            SEDlog.WriteInFile(" Последняя запись в файл: \t" + fi.LastWriteTime, "SEDfileinfo.txt");
           SEDlog.WriteInFile("Размер: \t" + fi.Length + " байт", "SEDfileinfo.txt");
            SEDlog.WriteInFile("  ", "SEDdickinfo.txt");
        }
    }
    class SEDdirinfo
    {
        public static void dirinfo(string name)
        {
            string[] names = Directory.GetDirectories(name);
            SEDlog.WriteInFile(Directory.GetCreationTime(name),"SEDdirinfo.txt");
            int i = 0;
            for (;i<names.Length;i++)
            SEDlog.WriteInFile(Convert.ToString(i)+": "+names[i], "SEDdirinfo.txt");
            SEDlog.WriteInFile("Кол-во папок: "+names.Length, "SEDdirinfo.txt");
            SEDlog.WriteInFile("Родительский каталог: "+Directory.GetParent(name),"SEDdirinfo.txt");
            SEDlog.WriteInFile("  ", "SEDdirinfo.txt");
        }
    }
    class SEDfilemanager
    {
        static FileInfo f;
        public static void getfiles(string name)
        {
            string newdir=name+"NewDirectory";
            Directory.CreateDirectory(newdir);
            string[] names = Directory.GetFiles(name);
            int i = 0;
            for (; i < names.Length; i++)
                SEDlog.WriteInFile(Convert.ToString(i) + ": " + names[i],newdir+ @"\SEDdirinfo.txt");
            SEDlog.WriteInFile("Кол-во папок: " + names.Length, newdir+@"\SEDdirinfo.txt");
            SEDlog.WriteInFile(" ",newdir+@"\SEDdirinfo.txt");
            f = new FileInfo(newdir+@"\SEDdirinfo.txt");
            f.CopyTo(newdir + @"\SEDdirinfo(copy).txt");
            f.Delete();

           string newdir1 = name + @"New Directory 1\";
            Directory.CreateDirectory(newdir1);

            string[] n1 = Directory.GetFiles(@"d:\торент");
            for (int i1 = 0; i1 < n1.Length; i1++)
                File.Copy(n1[i1],newdir1+"a.txt"+i1);
            // Console.WriteLine("Введите путь директория из которого производить копиование: ");
            /*string str = @"d:\торент";//Console.ReadLine();
            f = new FileInfo(str);
            //f.CopyTo(@"d:\торент111111\");
            File.Copy(@"d:\торент\", @"d:\торент111111\");
            */
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SEDlog.WriteInFile("Начало работы: ");
            
            SEDlog.CreateFile();

            SEDdiskinfo.GetInfo();
            
            SEDfileinfo.fileinfo("SEDdickinfo.txt");

            SEDdirinfo.dirinfo(@"c:\");

            SEDfilemanager.getfiles(@"d:\");

            SEDlog.CloseFile();


            
        }
    }
}
