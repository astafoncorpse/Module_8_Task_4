using FinalTask;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module_8_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var workDir = @"C:\Students\";
            var filePath = $"{workDir}Students.dat";

            var formatter = new BinaryFormatter();
            Student[] students;
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                //Десериализация данных из файла в массив класса Student
                students = (Student[])formatter.Deserialize(fs);
            }
            Console.WriteLine($"Всего получено {students.Length} студентов");

            //Группировка студентов по группам
            var grouppedStudents = students.GroupBy(s => s.Group);

            Console.WriteLine($"Всего найдено {grouppedStudents.Count()} групп");

            //Цикл по группам
            foreach (var group in grouppedStudents)
            {
                var groupName = group.Key; //название группы
                var newFilePath = $"{workDir}{groupName}.txt";
                List<string> newFileLines = new List<string>(); // массив строк для нового файла группы.
                foreach (var student in group)
                {
                    var newLine = student.ToString(); // вызов переопределенного метода ToString() класса Student, который возвращает строку, содержащую имя и фамилию
                    newFileLines.Add(newLine);  // добавление строки в  массив строк для нового файла группы.
                }

                File.AppendAllLines(newFilePath, newFileLines); // сохранение всех строк в новый файл группы
                Console.WriteLine($"Студенты группы {group.Key} записаны в файл {newFilePath}");
            }
        }
    }
}

