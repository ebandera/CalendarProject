using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CalendarProject
{
    class FileProcessor
    {
        string currentDirectoryFullPath;
        string currentWorkingFileName;
        string currentDBFileName;
        List<string> lstBackups = new List<string>();

        public FileProcessor()
        {
            currentDirectoryFullPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Calendar";
            currentWorkingFileName = "BirthdayData.accdb";
            currentDBFileName = currentDirectoryFullPath + "\\" + currentWorkingFileName;

        }
        public void MakeBackupFile()
        {
            string dateString = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            File.Copy(currentDBFileName, currentDirectoryFullPath + "\\Backup" + dateString + ".accdb");
                
        }
        public void RecoverBackupFile(string fileName)
        {
            File.Copy(currentDirectoryFullPath + "\\" + fileName,currentDBFileName);
        }
        public List<string>GetAllBackupFilenames()
        {
            string[] fileEntries = Directory.GetFiles(currentDirectoryFullPath);
            int entryCount = fileEntries.Length;
            List<string> lstFiles = new List<string>();
            for(int i=0;i<entryCount;i++)
            {
                if(Path.GetFileName(fileEntries[i])!="BirthdayData.accdb")
                {
                    lstFiles.Add(Path.GetFileName(fileEntries[i]));
                }
            }
            return lstFiles;
        }
        public void DeleteFile(string fileName)
        {
            File.Delete(currentDirectoryFullPath + "\\" + fileName);

        }
    }
}
