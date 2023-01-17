using System;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }

        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Переопределенный метод для удобного отображения данных студента
        /// </summary>
        /// <returns>Строка, содержащая имя и дату рождения студента</returns>
        public override string ToString()
        {
            return $"Имя: {Name}. Дата рождения: {DateOfBirth.ToShortDateString()}";
        }
    }
}
