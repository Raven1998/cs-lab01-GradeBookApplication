﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            List<Student> worse = Students.FindAll(student => student.AverageGrade < averageGrade);
            int worseStudentsCount = worse.Count;
            double worsePercentage = (double)worseStudentsCount / (double)Students.Count * (double)100;

            if (worsePercentage >= 80)
                return 'A';
            else if (worsePercentage >= 60)
                return 'B';
            else if (worsePercentage >= 40)
                return 'C';
            else if (worsePercentage >= 20)
                return 'D';
            else
                return 'F';
        }
    }
}
