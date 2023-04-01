using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
            Name = name;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            int i = 0;
            double[] LetterTop = new double[Students.Count()];
            foreach (var student in Students)
            {
                LetterTop[i] = student.AverageGrade;
                i++;
            }

            Array.Sort(LetterTop);
            Console.WriteLine(LetterTop.Length);
            double LetterPlace = 0;
            double c = LetterTop.Length;
            double d = 0;

            for (int j = 0; j < LetterTop.Length; j++)
            {
                d = (j - c) * -1;
                if (LetterTop[j] == averageGrade)
                {
                    LetterPlace = (d / c) * 100;
                }
                double LetterPlace2 = ((j + 1) / c) * 100;
                Console.WriteLine(LetterTop[j] + " " + j + " " + LetterPlace + " " + LetterPlace2 + " " + averageGrade);
                Console.WriteLine(LetterTop[j] == averageGrade);
            }

            if (LetterPlace <= 20)
            {
                return 'A';
            }
            else if (LetterPlace > 20 && LetterPlace <= 40)
            {
                return 'B';
            }
            else if (LetterPlace > 40 && LetterPlace <= 60)
            {
                return 'C';
            }
            else if (LetterPlace > 60 && LetterPlace <= 80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }

            
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }

            if (Students.Count >= 5)
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }

            if (Students.Count >= 5)
                base.CalculateStudentStatistics(name);
        }
    }
}
