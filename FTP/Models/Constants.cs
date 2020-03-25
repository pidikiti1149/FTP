using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FTP.Models
{
    public class Constants
    {
        
        public class Locations
        {
            public readonly static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            public readonly static string ExePath = Environment.CurrentDirectory;

            public readonly static string ContentFolder = $"{ExePath}\\..\\..\\..\\Content";
            public readonly static string DataFolder = $"{ContentFolder}//Data";
            public readonly static string ImagesFolder = $"{ContentFolder}\\Images";

            public const string InfoFile = "info.csv";
            public const string ImageFile = "myimage.jpg";
        }

        public class FTP1
        {
            public const string Username = @"bdat100119f\bdat1001";
            public const string Password = "bdat1001";

            public const string BaseUrl = "ftp://waws-prod-dm1-127.ftp.azurewebsites.windows.net/bdat1001-20914";

            public const int OperationPauseTime = 100000;
        }

        public class Student
        {
            public const string InfoCSVFileName = "info.csv";
            public const string MyImageFileName = "myimage.jpg";
        }
    }

}
