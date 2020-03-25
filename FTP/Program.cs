using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FTP.Models;

namespace FTP
{
    class Program
    {
        static void Main(string[] args)
        {


            Student myrecord = new Student { StudentId = "200429757", FirstName = "Aditya", LastName = "Pidikiti" };
            List<Student> students = new List<Student>();
            List<string> directories = FTP1.GetDirectory(Constants.FTP1.BaseUrl);



            foreach (var directory in directories)
            {
                Student student = new Student() { AbsoluteUrl = Constants.FTP1.BaseUrl };
                student.FromDirectory(directory);
                Console.WriteLine(directory);
                Console.WriteLine(student);
                string infoFilePath = student.FullPathUrl + "/" + Constants.Locations.InfoFile;
                string imageFilePath = student.FullPathUrl + "/" + Constants.Locations.ImageFile;


                bool fileExists = FTP1.FileExists(infoFilePath);
                if (FTP1.FileExists(student.InfoCSVPath))
                {
                    var csvBytes = FTP1.DownloadFileBytes(student.InfoCSVPath);

                    string csvFileData = Encoding.ASCII.GetString(csvBytes, 0, csvBytes.Length);

                    string[] data = csvFileData.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (data.Length != 2)
                    {
                        Console.WriteLine("Error in your Age");
                    }
                    else
                    {
                        student.FromCSV(data[1]);
                        Console.WriteLine("Age:" + student.Age);
                    }


                }
                if (fileExists == true)
                {
                    string csvPath = $@"/Users/adityapidikiti/Downloads/Files/{directory}.csv";

                    FTP1.DownloadFile(infoFilePath, csvPath);
                    Console.WriteLine("Found info file:");
                }
                else
                {
                    Console.WriteLine("Could not find info file:");
                }

                Console.WriteLine("\t" + infoFilePath);



                bool imageFileExists = FTP1.FileExists(imageFilePath);

                if (imageFileExists == true)
                {

                    Console.WriteLine("Found image file:");
                }
                else
                {
                    Console.WriteLine("Could not find image file:");
                }

                Console.WriteLine("\t" + imageFilePath);

                students.Add(student);
            }

            //Save to CSV
            string studentsCSVPath = $"{Constants.Locations.DataFolder}//students.csv";




            int count = students.Count();
            Console.WriteLine("Number of students:" + count);

            string inputStartsWith = "P";
            string inputContains = "pa";
            int countStartsWith = 0;
            int countContains = 0;
            foreach (var list in students)
            {
                string string1 = list.LastName;
                if (string1.StartsWith(inputStartsWith))
                {
                    Console.WriteLine("Last starts with " + inputStartsWith + " " + list);
                    countStartsWith++;
                }
            }
            Console.WriteLine("Number of people having LastName that starts with 'P':" + countStartsWith);
            foreach (var list1 in students)
            {
                string string1 = list1.LastName;
                if (string1.Contains(inputContains))
                {
                    Console.WriteLine("Last name starts with " + inputContains + " " + list1);
                    countContains++;
                }
            }
            Console.WriteLine("Number of people having LastName that contains 'pa':" + countContains);

            Student me = students.SingleOrDefault(x => x.StudentId == myrecord.StudentId);
            Student meUsingFind = students.Find(x => x.StudentId == myrecord.StudentId);


            var avgage = students.Average(x => x.Age);
            var minage = students.Min(x => x.Age);
            var maxage = students.Max(x => x.Age);

            Console.WriteLine("Average Age:" + avgage);
            Console.WriteLine("Highest Age:" + maxage);
            Console.WriteLine("Lowest Age:" + minage);

            
        }
    }
}