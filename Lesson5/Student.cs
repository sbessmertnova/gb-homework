using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Student
    {
        public string Name { get; }

        public string LastName { get; }

        public int[] Marks { get; }

        public double MiddleMark { get; }

        public Student(string studentRawValue)
        {
            var studentValues = studentRawValue.Split(' ');
            if (studentValues[0].Length>20)
            {
                throw new Exception("Фамилия не должна быть длиннее 20 символов");
            }
            LastName = studentValues[0];
            if (studentValues[1].Length > 15)
            {
                throw new Exception("Имя не должно быть длиннее 15 символов");
            }
            Name = studentValues[1];
            Marks = new int[]
            {
                int.Parse(studentValues[2]),
                int.Parse(studentValues[3]),
                int.Parse(studentValues[4])
            };
            MiddleMark = Marks.Average();

        }

        public override string ToString()
        {
            return $"{LastName} {Name} {string.Join(' ', Marks)} средний балл: {MiddleMark}";
        }
    }
}
